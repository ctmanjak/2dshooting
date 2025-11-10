using System;
using _02Scripts.Common.Component.AI.Move;
using _02Scripts.Common.Component.Stat;
using _02Scripts.Player.Enum;
using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Player.Component.AI
{
    [RequireComponent(typeof(PlayerMovableAreaComponent), typeof(MoveStatComponent))]
    public class PlayerMoveAIComponent : TargetMoveAIComponent
    {
        private PlayerMovableAreaComponent _playerMovableAreaComponent;
        private MoveStatComponent _moveStatComponent;
        
        private EMoveAIState _state;
        
        private Vector2 _moveDirection;
        private int _toCenterDirection;

        private Collider2D[] _dangerColliders;
        private ETargetType _targetType;
        
        public float SafeDistance = 1f;
        public float DetectionRangeY = 1f;
        public float SafeBottomCushion = 1f;
        
        public float CenterInnerBand = 1f;
        public float CenterOuterBand = 2f;

        public float InterceptTargetDistance = 1f;
        public LayerMask DangerLayer;
        
        protected override Vector2 GetMoveDirection()
        {
            if (!Mathf.Approximately(_moveDirection.y, -1f) ||
                transform.position.y > _playerMovableAreaComponent.MovableBottomLeft.y) return _moveDirection;
            
            _moveDirection.y = 0;
            
            if (!Mathf.Approximately(_moveDirection.x, 0f)) return _moveDirection;
            
            Vector2 toCenter = transform.position.normalized;
            _moveDirection.x = -toCenter.x;
            return _moveDirection;
        }
        
        protected override void Init()
        {
            base.Init();

            _playerMovableAreaComponent = GetComponent<PlayerMovableAreaComponent>();
            _moveStatComponent = GetComponent<MoveStatComponent>();
            
            _state = EMoveAIState.Idle;
            _moveDirection = Vector2.zero;
            
            SetTarget(null);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + new Vector3(0, DetectionRangeY, 0), SafeDistance);
        }
        
        private GameObject FindClosest(string objectTag, Func<GameObject, bool> extraFilter = null)
        {
            Vector2 playerPosition = transform.position;
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(objectTag);

            GameObject closestGameObject = null;
            float closestSqrMagnitude = float.MaxValue;

            foreach (var obj in gameObjects)
            {
                if (extraFilter != null && !extraFilter(obj)) continue;

                float sqrMagnitude = ((Vector2)obj.transform.position - playerPosition).sqrMagnitude;
                if (sqrMagnitude >= closestSqrMagnitude) continue;

                closestGameObject = obj;
                closestSqrMagnitude = sqrMagnitude;
            }

            return closestGameObject;
        }

        private GameObject FindClosestItem()
        {
            return FindClosest("Item", obj =>
            {
                Vector2 movableTopRight = _playerMovableAreaComponent.MovableTopRight;
                Vector2 movableBottomLeft = _playerMovableAreaComponent.MovableBottomLeft;

                return obj.transform.position.x >= movableBottomLeft.x
                       && obj.transform.position.x <= movableTopRight.x
                       && obj.transform.position.y >= movableBottomLeft.y
                       && obj.transform.position.y <= movableTopRight.y;
            });
        }

        private GameObject FindClosestEnemy()
        {
            return FindClosest("Enemy", obj =>
                obj.transform.position.y > _playerMovableAreaComponent.MovableTopRight.y);
        }

        protected override void BeforeMove()
        {
            FindTarget();
            FindDanger();
            switch (_state)
            {
                case EMoveAIState.Idle:
                    UpdateIdle();
                    break;
                case EMoveAIState.Approach:
                    UpdateApproach();
                    break;
                case EMoveAIState.Retreat:
                    UpdateRetreat();
                    break;
            }
        }

        private void ChangeState(EMoveAIState state)
        {
            _state = state;
        }

        private void UpdateIdle()
        {
            if (IsDanger())
            {
                ChangeState(EMoveAIState.Retreat);
                return;
            }
            
            if (IsTargetExist())
            {
                ChangeState(EMoveAIState.Approach);
                return;
            }
            
            IdleMove();
        }

        private void UpdateApproach()
        {
            if (!IsTargetExist())
            {
                ChangeState(EMoveAIState.Idle);
                return;
            }

            if (IsDanger())
            {
                RemoveTargetIfInDanger();
                ChangeState(EMoveAIState.Retreat);
                return;
            }
            
            ApproachMove();
        }

        private void UpdateRetreat()
        {
            if (!IsDanger())
            {
                ChangeState(!IsTargetExist() ? EMoveAIState.Idle : EMoveAIState.Approach);
                return;
            }
            
            RetreatMove();
        }

        private bool IsDanger()
        {
            return _dangerColliders.Length > 0;
        }

        private void RemoveTargetIfInDanger()
        {
            GameObject target = GetTarget();
            foreach (var dangerCollider in _dangerColliders)
            {
                if (target == dangerCollider.gameObject
                    && transform.position.y <= _playerMovableAreaComponent.MovableBottomLeft.y + SafeBottomCushion) SetTarget(null);
            }
        }

        private void FindDanger()
        {
            _dangerColliders = GetDangerCollider2D();
        }

        private Collider2D[] GetDangerCollider2D()
        {
            return Physics2D.OverlapCircleAll(transform.position + new Vector3(0, DetectionRangeY, 0), SafeDistance, DangerLayer);
        }

        private void IdleMove()
        {
            Vector2 movableTopRight = _playerMovableAreaComponent.MovableTopRight;
            Vector2 movableBottomLeft = _playerMovableAreaComponent.MovableBottomLeft;

            Vector2 toCenter = (movableTopRight + movableBottomLeft) / 2f - (Vector2)transform.position;

            _moveDirection = DirectionUtil.SnapTo8Direction(toCenter);

            if (!CanContinueMoving(toCenter)) _moveDirection = Vector2.zero;
        }

        private void ApproachMove()
        {
            Vector2 approachDirection = _targetType == ETargetType.Enemy
                ? GetEnemyApproachDirection()
                : GetItemApproachDirection();
            
            _moveDirection = DirectionUtil.SnapTo8Direction(approachDirection);
        }

        private bool CanContinueMoving(Vector2 toTargetDirection)
        {
            Vector2 direction = DirectionUtil.SnapTo8Direction(toTargetDirection / toTargetDirection.magnitude);
            float forwardDist = Vector2.Dot(toTargetDirection, direction);
            float step = _moveStatComponent.GetSpeed() * Time.fixedDeltaTime;
            
            return forwardDist > step;
        }

        private Vector2 GetEnemyApproachDirection()
        {
            Vector2 playerPosition = transform.position;
            Vector2 targetPosition = GetTargetPosition();

            Vector2 approachDirection = Vector2.zero;
            if (targetPosition.y <= playerPosition.y) return approachDirection;

            Vector2 toTarget = targetPosition - playerPosition; 
            approachDirection = toTarget.normalized;
            approachDirection.y = 0;

            toTarget.y = 0;
            if (!CanContinueMoving(toTarget)) approachDirection = Vector2.zero;
            return approachDirection;
        }

        private Vector2 GetItemApproachDirection()
        {
            return GetTargetDirection();
        }

        private void RetreatMove()
        {
            Vector2 playerPosition = transform.position;
            if (_dangerColliders.Length < 1) return;
            
            Vector2 retreatDirection = Vector2.zero;

            foreach (var dangerCollider in _dangerColliders)
            {
                Vector2 colliderPos = dangerCollider.ClosestPoint(playerPosition);
                Vector2 awayDirection = playerPosition - colliderPos;

                float distance = awayDirection.magnitude;

                awayDirection /= distance * distance;

                retreatDirection += awayDirection;
            }

            _moveDirection = DirectionUtil.SnapTo8Direction(retreatDirection.normalized);

            if (playerPosition.y > _playerMovableAreaComponent.MovableBottomLeft.y + SafeBottomCushion) return;
            
            retreatDirection.y = 0;

            int toCenterDirection = GetCenterHorizontalDirection(transform.position.x);
            if (toCenterDirection != 0) retreatDirection.x = toCenterDirection;
            else retreatDirection.x = 1f;

            _moveDirection = DirectionUtil.SnapTo8Direction(retreatDirection.normalized);
        }

        private int GetCenterHorizontalDirection(float x)
        {
            if (Mathf.Abs(x) < CenterInnerBand)
            {
                _toCenterDirection = 0;
                return 0;
            }

            if (x < -CenterOuterBand)
            {
                _toCenterDirection = 1;
                return 1;
            }

            if (x > CenterOuterBand)
            {
                _toCenterDirection = -1;
                return -1;
            }

            return _toCenterDirection;
        }

        private void FindTarget()
        {
            GameObject closestItem = FindClosestItem();
            
            if (IsTargetExist())
            {
                Vector2 targetPosition = GetTargetPosition();
                Vector2 playerPosition = transform.position;
                if (targetPosition.y <= playerPosition.y) SetTarget(null);

                float targetDistance = (targetPosition - playerPosition).magnitude;
                float closestItemDistance = closestItem
                    ? ((Vector2)closestItem.transform.position - playerPosition).magnitude
                    : float.MaxValue;
                if (targetDistance > closestItemDistance + InterceptTargetDistance) SetTarget(closestItem, ETargetType.Item);
                else return;
            }
            
            if (closestItem)
            {
                SetTarget(closestItem, ETargetType.Item);
                return;
            }
            
            GameObject closestEnemy = FindClosestEnemy();
            if (closestEnemy)
            {
                SetTarget(closestEnemy, ETargetType.Enemy);
                return;
            }
            
            SetTarget(null);
        }

        private void SetTarget(GameObject target, ETargetType type)
        {
            SetTarget(target);
            _targetType = type;
        }
    }
}

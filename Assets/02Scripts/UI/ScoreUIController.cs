using _02Scripts.Score;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _02Scripts.UI
{
    public class ScoreUIController : MonoBehaviour
    {
        [SerializeField] private Text _scoreTextUI;
        [SerializeField] private Text _highScoreTextUI;

        private RectTransform _scoreTextUIRectTransform;

        public ScoreManager ScoreManager;

        public bool UseUnscaledTime = true;
        public float ScaleValue = 3f;
        public float ScaleDuration = 0.5f;
        public Ease ScaleEase = Ease.OutBack;

        public float ShakePositionDuration = 1f;
        public Vector2 ShakePositionStrength = new(100f, 100f);
        public int ShakePositionVibrato = 10;
        public float ShakePositionRandomness = 90F;
        public bool ShakePositionSnapping = false;
        public bool ShakePositionFadeOut = true;
        public ShakeRandomnessMode ShakePositionRandomnessMode = ShakeRandomnessMode.Full;
        public int ShakePositionLoopTime = -1;
        public LoopType ShakePositionLoopType = LoopType.Restart;
        
        public float ShakeRotationDuration = 1f;
        public Vector3 ShakeRotationStrength = new(0f, 0f, 100f);
        public int ShakeRotationVibrato = 10;
        public float ShakeRotationRandomness = 90f;
        public bool ShakeRotationFadeOut = true;
        public ShakeRandomnessMode ShakeRotationRandomnessMode = ShakeRandomnessMode.Full;
        public int ShakeRotationLoopTime = -1;
        public LoopType ShakeRotationLoopType = LoopType.Restart;
        
        public float ReturnScaleDuration = 0.5f;
        public Ease ReturnScaleEase = Ease.OutQuad;
        public float ReturnPositionDuration = 0.5f;
        public Ease ReturnPositionEase = Ease.OutQuad;
        public float ReturnRotationDuration = 0.5f;
        public Ease ReturnRotationEase = Ease.OutQuad;

        public float CalmDelay = 0.5f;

        private Vector2 _scoreInitialPosition;
        private Quaternion _scoreInitialRotation;

        private Tween _scaleTween;
        private Tween _shakePositionTween;
        private Tween _returnPositionTween;
        private Tween _shakeRotationTween;
        private Tween _returnRotationTween;
        private Tween _calmTimer;

        private void Awake()
        {
            if (!ScoreManager) return;
            ScoreManager.OnHighScore += PlayEffect;
            ScoreManager.OnScoreChanged += UpdateScoreText;
            ScoreManager.OnHighScoreChanged += UpdateHighScoreText;

            _scoreTextUIRectTransform = _scoreTextUI.rectTransform;
            _scoreInitialPosition = _scoreTextUIRectTransform.anchoredPosition;
            _scoreInitialRotation = _scoreTextUIRectTransform.rotation;
        }

        private void UpdateScoreText(int score)
        {
            if (!_scoreTextUI) return;
            _scoreTextUI.text = score.ToString("N0");
        }

        private void UpdateHighScoreText(int highScore)
        {
            if (!_highScoreTextUI) return;
            _highScoreTextUI.text = highScore.ToString("N0");
        }

        private void PlayEffect()
        {
            ScaleEffect(_scoreTextUIRectTransform);
            ShakeEffect(_scoreTextUIRectTransform);
            StartCalmTimer(_scoreTextUIRectTransform);
            
        }

        private void StartCalmTimer(RectTransform rectTransform)
        {
            _calmTimer?.Kill();
            _calmTimer = DOVirtual.DelayedCall(CalmDelay, () => RestoreEffect(rectTransform), UseUnscaledTime);
        }

        private void ScaleEffect(RectTransform rectTransform)
        {
            _scaleTween?.Kill();
            _scaleTween = rectTransform
                .DOScale(ScaleValue, ScaleDuration)
                .SetEase(ScaleEase)
                .SetUpdate(UseUnscaledTime);
        }

        private void RestoreEffect(RectTransform rectTransform)
        {
            _shakePositionTween?.Kill();
            _shakeRotationTween?.Kill();
            
            _scaleTween?.Kill();
            _scaleTween = rectTransform
                .DOScale(1f, ReturnScaleDuration)
                .SetEase(ReturnScaleEase)
                .SetUpdate(UseUnscaledTime);
            
            _returnPositionTween?.Kill();
            _returnPositionTween = rectTransform
                .DOAnchorPos(_scoreInitialPosition, ReturnPositionDuration)
                .SetEase(ReturnPositionEase)
                .SetUpdate(UseUnscaledTime);
            
            _returnRotationTween?.Kill();
            _returnRotationTween = rectTransform
                .DORotateQuaternion(_scoreInitialRotation, ReturnRotationDuration)
                .SetEase(ReturnRotationEase)
                .SetUpdate(UseUnscaledTime);
        }

        private void ShakeEffect(RectTransform rectTransform)                   
        {
            _shakePositionTween?.Kill();
            _shakePositionTween = rectTransform
                .DOShakeAnchorPos(
                    ShakePositionDuration,
                    ShakePositionStrength,
                    ShakePositionVibrato,
                    ShakePositionRandomness,
                    ShakePositionSnapping,
                    ShakePositionFadeOut,
                    ShakePositionRandomnessMode
                )
                .SetLoops(ShakePositionLoopTime, ShakePositionLoopType)
                .SetUpdate(UseUnscaledTime);
            
            _shakeRotationTween?.Kill();
            _shakeRotationTween = rectTransform
                .DOShakeRotation(
                    ShakeRotationDuration,
                    ShakeRotationStrength,
                    ShakeRotationVibrato,
                    ShakeRotationRandomness,
                    ShakeRotationFadeOut,
                    ShakeRotationRandomnessMode
                )
                .SetLoops(ShakeRotationLoopTime, ShakeRotationLoopType)
                .SetUpdate(UseUnscaledTime);
        }
    }
}
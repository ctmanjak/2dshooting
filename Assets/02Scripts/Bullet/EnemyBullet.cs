using UnityEngine;

namespace _02Scripts.Bullet
{
    public class EnemyBullet : BaseBullet
    {
        public override void Init(int damage = 0, Vector3? position = null, Quaternion? rotation = null)
        {
            base.Init(damage, position, rotation);
            EnemyTags = new[] { "Player" };
        }
    }
}

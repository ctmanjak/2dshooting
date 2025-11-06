using UnityEngine;

namespace _02Scripts.Bullet
{
    public class EnemyBullet : BaseBullet
    {
        public override void Init(int damage = 0, Quaternion? rotation = null)
        {
            base.Init(damage, rotation);
            EnemyTags = new[] { "Player" };
        }
    }
}

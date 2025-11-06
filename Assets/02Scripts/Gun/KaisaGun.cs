using _02Scripts.Bullet;
using UnityEngine;

namespace _02Scripts.Gun
{
    public class KaisaGun : GenericBaseGun<KaisaBullet>
    {
        public float SpawnPointX = 0.5f;
        public float MidpointX = 10f;
        public float MidpointY = 10f;
        public float MidpointRadius = 5f;
        public float EndpointY = 10f;

        protected override void InstantiateBullet(int damage, Quaternion rotation)
        {
            InstantiateKaisaBullet(damage, SpawnPointX, MidpointX);
            InstantiateKaisaBullet(damage, -SpawnPointX, -MidpointX);
        }

        private void InstantiateKaisaBullet(int damage, float spawnPointX, float midPointX)
        {
            Vector2 position = transform.position;
            position.x += spawnPointX;
            
            KaisaBullet bullet = Instantiate(BulletPrefab, position, transform.rotation);
            bullet.Init(damage);
            
            Vector2 firstPoint = position;
            firstPoint.x += spawnPointX;
            
            Vector2 midpoint = firstPoint;
            midpoint.x += midPointX - spawnPointX;
            midpoint.y -= MidpointY;
            midpoint += Random.insideUnitCircle * MidpointRadius;

            Vector2 lastPoint = position + Vector2.up * EndpointY;
            
            bullet.InitPoint(firstPoint, midpoint, lastPoint);
        }
    }
}

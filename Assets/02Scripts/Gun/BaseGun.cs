using _02Scripts.Bullet;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseGun : MonoBehaviour
{
    public BaseBullet BulletPrefab;
    public float FireCooldown = 1.0f;

    private float _lastFireTime;

    private void Start()
    {
        _lastFireTime = Time.time - FireCooldown;
    }
    
    public virtual void Fire()
    {
        if (Time.time - _lastFireTime >= FireCooldown)
        {
            InstantiateBullet(transform.position, transform.rotation);

            _lastFireTime = Time.time;
        }
    }

    protected virtual void InstantiateBullet(Vector3 position, Quaternion rotation)
    {
        BaseBullet bullet = Instantiate(BulletPrefab);
        bullet.Init(position, rotation);
        bullet.transform.position = transform.position;
    }
}

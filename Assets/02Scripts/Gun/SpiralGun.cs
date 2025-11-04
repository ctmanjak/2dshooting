using UnityEngine;

public class SpiralGun : BaseGun
{
    public float RotateSpeed = 10.0f;

    protected override void InstantiateBullet(Vector3 position, Quaternion rotation)
    {
        base.InstantiateBullet(position, rotation);
        
        transform.rotation *= Quaternion.AngleAxis(RotateSpeed, Vector3.forward);
    }
}

using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public BaseGun[] Guns;

    private EFireType _fireType;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetFireType(EFireType.Auto);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetFireType(EFireType.Manual);
        }
        
        if (_fireType == EFireType.Auto || Input.GetKey(KeyCode.Space))
        {
            foreach (var gun in Guns)
            {
                if (gun && gun.gameObject.activeSelf) gun.Fire();
            }
        }
    }

    private void SetFireType(EFireType fireType)
    {
        _fireType = fireType;
    }
}

public enum EFireType
{
    Auto,
    Manual
}
using _02Scripts.Player;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private StatComponent _statComponent;
    public BaseGun[] Guns;

    private EFireType _fireType;

    private void Start()
    {
        _statComponent = GetComponent<StatComponent>();
    }

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
                if (gun && gun.gameObject.activeSelf) gun.Fire(_statComponent.Damage);
            }
        }
    }

    private void SetFireType(EFireType fireType)
    {
        _fireType = fireType;
    }
}
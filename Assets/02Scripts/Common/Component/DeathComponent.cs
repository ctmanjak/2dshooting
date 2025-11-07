using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    [RequireComponent(typeof(StatComponent))]
    public class DeathComponent : MonoBehaviour
    {
        private void Start()
        {
            Init();
        }

        protected virtual void Init() {}
        
        public virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
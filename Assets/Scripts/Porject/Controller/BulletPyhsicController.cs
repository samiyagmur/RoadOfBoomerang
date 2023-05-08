using Interfaces;
using Scripts.Level.Manager;
using Signals;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class BulletPyhsicController : MonoBehaviour, IPushObject
    {
        [SerializeField]
        private BulletManager bullutManager;

        private void OnTriggerEnter(Collider other)
        {
            PushToPool(PoolObjectType.Bullet, transform.parent.gameObject);
        }

        public float TakeDamage()
        {
            return bullutManager.Damage;
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}
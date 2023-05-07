using Interfaces;
using Scripts.Helper.Interfaces;
using Scripts.Level.Manager;
using Signals;
using System.Collections;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PlayerPhysicController : MonoBehaviour,IPushObject
    {
        [SerializeField]
        private PlayerManager playerManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BulletPyhsicController bulletPyhsicController))
            {
                playerManager.HitDamager(bulletPyhsicController.TakeDamage());
            }

            if (other.CompareTag("Coin"))
            {

                playerManager.HitCoin();

                PushToPool(PoolObjectType.SmallGold, other.transform.parent.gameObject);
            }
        }
        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}
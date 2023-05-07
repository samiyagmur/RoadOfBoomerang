using Assets.Scripts.Level.Manager;
using Interfaces;
using Scripts.Helper.Interfaces;
using Signals;
using System.Collections;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class EnemyPhysicController : MonoBehaviour, IEnemyable,IPushObject
    {
        [SerializeField]
        private EnemyManager enemyManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerDetectController playerDetectController))
            {
                enemyManager.EnterDetectArea();


            }

            if (other.TryGetComponent(out BoomerangPhysicController boomerangPhysicController))
            {
                enemyManager.OnHitBoomerang();

                PushToPool(PoolObjectType.Enemy, transform.parent.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerDetectController playerDetectController))
            {
                enemyManager.ExitDetectArea();
            }
        }



        public GameObject GetHitEnemy()
        {
            return transform.parent.gameObject;
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}
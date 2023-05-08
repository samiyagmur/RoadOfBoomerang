using Assets.Scripts.Level.Manager;
using Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using Signals;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class EnemyAttackController : MonoBehaviour, IPullObject
    {
        public bool IsActive { get; set; }

        [SerializeField]
        private GameObject spawnPosition;

        [SerializeField]
        private EnemyManager enemyManager;

        private EnemyAttackData _enemyAttackData;

        internal void SetData(EnemyAttackData enemyAttackData)
        {
            _enemyAttackData = enemyAttackData;
        }

        public void TriggerToAction()
        {
            if (!IsActive) return;

            Attack();
        }

        private void Attack()
        {
            GameObject bullet = PullFromPool(PoolObjectType.Bullet);

            bullet.transform.position = spawnPosition.transform.position;

            if (bullet.TryGetComponent(out BulletManager bulletmanager))
            {
                bulletmanager.Target = spawnPosition.transform;
            }
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }
    }
}
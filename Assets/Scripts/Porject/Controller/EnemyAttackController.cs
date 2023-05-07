using Assets.Scripts.Level.Manager;
using Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using Scripts.Level.Type;
using Signals;
using System;
using System.Collections;
using System.Threading.Tasks;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class EnemyAttackController : MonoBehaviour,IPullObject
    {
        [SerializeField]
        private GameObject spawnPosition;

        [SerializeField]
        private EnemyManager enemyManager;

        private EnemyAttackData _enemyAttackData;

        public bool IsAttaking { get ; set ; }

        internal void SetData(EnemyAttackData enemyAttackData)
        {
            _enemyAttackData = enemyAttackData;
        }

        public  void TriggerToAction()
        {
            Attack();

            if (IsAttaking)
            {
               
            }

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
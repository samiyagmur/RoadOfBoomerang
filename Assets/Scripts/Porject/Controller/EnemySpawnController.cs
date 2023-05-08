using Interfaces;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using Signals;
using Type;
using UnityEngine;
using Scripts.Extetions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Scripts.Level.Controller
{
    public class EnemySpawnController :ISpawner, IPullObject, IPushObject
    {
        public bool IsActivating { get; set; }

        private List<GameObject> _spawnedObject = new();

        private SpawnManager _spawnManager;

        private EnemySpawnData _enemySpawnData;

        public EnemySpawnController(SpawnManager spawnManager)
        {
            _spawnManager = spawnManager;

            _enemySpawnData = _spawnManager.SpawnData.enemySpawnData;
        }

        public void TriggerAction()
        {
            if (!IsActivating) return;

            SpawnFactory();
        }

        private async void SpawnFactory()
        {
            for (int i = 0; i < 1; i++)
            {
                if (!IsActivating) break;

                await Task.Delay((int)_enemySpawnData.spawnRange);

                Spawn();
            }
        }

        public void Spawn()
        {
            GameObject enemy = PullFromPool(PoolObjectType.Enemy);

            _spawnedObject.Add(enemy);

            enemy.transform.position = SelfExtetions.GetRandomTopPosition(_enemySpawnData.enemySpawnZone);
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }

        public void Reset()
        {
            foreach (var item in _spawnedObject)
            {
                PushToPool(PoolObjectType.Enemy, item);
            }
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool.Invoke(poolObjectType, obj);
        }
    }
}
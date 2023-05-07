using Interfaces;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using Signals;
using Type;
using UnityEngine;
using Scripts.Extetions;
using System.Threading.Tasks;
using Random = UnityEngine.Random;
using Data.ValueObject;

namespace Scripts.Level.Controller
{
    public class EnemySpawnController :IActivable, IPullObject
    {

        public bool IsActivating { get; set; }

        private int _counter;

        private SpawnManager _spawnManager;

        private EnemySpawnData _enemySpawnData;


        public EnemySpawnController(SpawnManager spawnManager)
        {
            _spawnManager = spawnManager;

            _enemySpawnData = _spawnManager.SpawnData.enemySpawnData;
        }

        public void TriggerAction()
        {
            //if (!IsActivating) return;

            SpawnFactory();
        }

        private async void SpawnFactory()
        {
            while (_counter < 1)
            {
                if (!IsActivating) break;

                await Task.Delay((int)_enemySpawnData.spawnRange);

                 StartAction();

                _counter++;
            }
        }

        public void StartAction()
        {
            GameObject enemy = PullFromPool(PoolObjectType.Enemy);

            enemy.transform.position = SelfExtetions.GetRandomTopPosition(_enemySpawnData.enemySpawnZone);
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }

    }
}
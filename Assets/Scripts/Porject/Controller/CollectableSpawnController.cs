using Data.ValueObject;
using Interfaces;
using Scripts.Extetions;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using Signals;
using System.Collections;
using System.Threading.Tasks;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class CollectableSpawnController :IActivable, IPullObject
    {


        private SpawnManager _spawnManager;


        private CollectableSpawnData _collectableSpawnData;

        private int _counter;

        public bool IsActivating { get ; set ; }

        public CollectableSpawnController(SpawnManager spawnManager)
        {
            _spawnManager = spawnManager;

            _collectableSpawnData = _spawnManager.SpawnData.collectableSpawnData;
        }

        public void TriggerAction()
        {
            if (!IsActivating) return;

            for (int _counter = 0; _counter < _collectableSpawnData.spawnLimit; _counter++) 
            {
                if (!IsActivating) break;

                StartAction();
            }
        }

        public void StartAction()
        {
            GameObject enemy = PullFromPool(PoolObjectType.SmallGold);

            enemy.transform.position = SelfExtetions.GetRandomTopPosition(_collectableSpawnData.collectableSpawnZone) + new Vector3(0,1,0);
        }


        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }
    }
}
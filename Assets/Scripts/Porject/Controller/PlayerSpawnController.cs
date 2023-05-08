using Interfaces;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using Signals;
using System.Collections.Generic;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PlayerSpawnController : ISpawner, IPullObject, IPushObject
    {
        public bool IsActivating { get; set; }

        private SpawnManager _spawnManager;

        private PlayerSpawnData _playerSpawnData;

        private List<GameObject> _spawnedObject = new();

        public PlayerSpawnController(SpawnManager spawnManager)
        {
            _spawnManager = spawnManager;

            _playerSpawnData = _spawnManager.SpawnData.playerSpawnData;
        }

        public void TriggerAction()
        {
            if (!IsActivating) return;

            Spawn();
        }

        public void Spawn()
        {
            GameObject player = PullFromPool(PoolObjectType.Player);

            player.transform.position = Vector3.zero;

            _spawnedObject.Add(player);
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }

        public void Reset()
        {
            foreach (var item in _spawnedObject)
            {
                PushToPool(PoolObjectType.Player, item);
            }
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool.Invoke(poolObjectType, obj);
        }
    }
}
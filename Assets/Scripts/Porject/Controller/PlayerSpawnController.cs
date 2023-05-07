using Data.ValueObject;
using Interfaces;
using Managers;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using Signals;
using System.Collections;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PlayerSpawnController :IActivable, IPullObject
    {
        public bool IsActivating { get; set; }

        private SpawnManager _spawnManager;

        private PlayerSpawnData _playerSpawnData;

        public PlayerSpawnController(SpawnManager spawnManager)
        {
            _spawnManager = spawnManager;

            _playerSpawnData = _spawnManager.SpawnData.playerSpawnData;
        }

        public void TriggerAction()
        {
            if (!IsActivating) return;

            StartAction();
        }

        public void StartAction()
        {
            GameObject enemy = PullFromPool(PoolObjectType.Player);

            enemy.transform.position = Vector3.zero;
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }
    }
}
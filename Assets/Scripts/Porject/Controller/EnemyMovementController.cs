using Assets.Scripts.Level.Manager;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Level.Controller
{
    public class EnemyMovementController :MonoBehaviour
    { 
        public bool IsActivating { get; set; }

        [SerializeField]
        private NavMeshAgent agent;

        [SerializeField]
        private EnemyManager enemyManager;

        private EnemyMovementData _enemyMovementData;

        private Transform _playerTransform;

        internal void SetData(EnemyMovementData enemyMovementData)
        {
            _enemyMovementData = enemyMovementData;
        }

        private void Update()
        {
            if (!IsActivating) return;

            _playerTransform = enemyManager.GetPlayerTransform();

             //StartMovement();
        }


        public void StartMovement()
        {
            agent.SetDestination(_playerTransform.position);
        }
    }
}
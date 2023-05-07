using Assets.Scripts.Level.Manager;
using Scripts.Extetions;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Type;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Level.Controller
{
    public class EnemyAnimationController : MonoBehaviour    
    {
        private EnemyAnimationData _enemyAnimationData;

        [SerializeField]
        private NavMeshAgent navMeshAgent;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private EnemyManager enemyManager;

        public bool IsActivating { get ; private set ; }
        public bool IsDead { get; private set; }
        public bool IsAttacking { get; private set; }

        internal void SetData(EnemyAnimationData enemyAnimationData)
        {
            _enemyAnimationData = enemyAnimationData;
        }

        public void OnReadyToAttack()
        {
            enemyManager.OnReadyToAttack();
        }

        public void AtackStop()
        {
            enemyManager.ActiveteController();

            ChangeAnimation(EnemyAnimationType.Run);
        }


        public void TriggerAction()
        {
            ChangeAnimation(EnemyAnimationType.Run);
        }

        public void StartAttack()
        {
            ChangeAnimation(EnemyAnimationType.Attack);
        }

        public void Dying()
        {
            ChangeAnimation(EnemyAnimationType.Die);
        }

        private void ChangeAnimation(EnemyAnimationType enemyAnimationType)
        {
            animator.Play(enemyAnimationType.ToString());
        }

    }
}
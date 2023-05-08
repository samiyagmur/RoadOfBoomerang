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

        public bool IsActive {private get ; set ; }

        internal void SetData(EnemyAnimationData enemyAnimationData)
        {
            _enemyAnimationData = enemyAnimationData;
        }

        public void OnEnemyDying()
        {
            enemyManager.OnEnemyDying();
        }

        public void OnReadyToAttack()
        {
            TriggerAction();
            enemyManager.OnReadyToAttack();
        }

        public void PlayRunAnimation()
        {
            enemyManager.ActiveteController();

            ChangeAnimation(EnemyAnimationType.Run);
        }


        public void TriggerAction()
        {
            ChangeAnimation(EnemyAnimationType.Run);
        }

        public void PlayAttackAnimation()
        {
            ChangeAnimation(EnemyAnimationType.Attack);
        }

        public void PlayDyingAnimation()
        {
            Debug.Log("ss");

            ChangeAnimation(EnemyAnimationType.Die);
        }

        private void ChangeAnimation(EnemyAnimationType enemyAnimationType)
        {
            animator.Play(enemyAnimationType.ToString());
        }

    }
}
using Scripts.Signals;
using Interfaces;
using Scripts.Level.Controller;
using Scripts.Level.Data.UnityObject;
using Scripts.Level.Data.ValueObject;
using System;
using System.Collections;
using UnityEngine;
using Script.Signals;
using Type;
using Signals;

namespace Assets.Scripts.Level.Manager
{
    public class EnemyManager : MonoBehaviour, IPushObject
    {
        [SerializeField]
        private EnemyMovementController enemyMovementController;

        [SerializeField]
        private EnemyAnimationController enemyAnimationController;

        [SerializeField]
        private EnemyAttackController enemyAttackController;

        [SerializeField]
        private EnemyPhysicController enemyPhysicController;

        private EnemyData _enemyData;

        private Transform _playerTransform;

        public string DataPath => "Data/Cd_EnemyData";

        public void Awake()
        {
            GetData();

            SetData();
        }


        public void GetData() => _enemyData = Resources.Load<Cd_EnemyData>(DataPath).EnemyData;


        public void SetData()
        {
            enemyMovementController.SetData(_enemyData.EnemyMovementData);

            enemyAnimationController.SetData(_enemyData.EnemyAnimationData);

            enemyAttackController.SetData(_enemyData.EnemyAttackData);
        }

        public void OnEnable()
        {
            ActiveteController();
        }

        public void OnDisable()
        {
            DeactiveController();
        }
        private void Start()
        {
            TriggerController();
        }
        public void TriggerController()
        {
            enemyPhysicController.OpenCollider();

            enemyAnimationController.TriggerAction();
        }

        public void ActiveteController()
        {
            enemyMovementController.IsActive = true;
            enemyAnimationController.IsActive = true;
            enemyAttackController.IsActive = true;
        }

        public void DeactiveController()
        {
            enemyMovementController.IsActive = false;
            enemyAnimationController.IsActive = false;
            enemyAttackController.IsActive = false;
        }

        internal void EnterDetectArea()
        {
            enemyAnimationController.PlayAttackAnimation();
        }

        internal void OnReadyToAttack()
        {
            enemyAttackController.TriggerToAction();
            
            ActiveteController();
        }

        internal void OnHitBoomerang()
        {
            enemyPhysicController.CloseCollider();

            enemyMovementController.IsActive = false;

            enemyAnimationController.PlayDyingAnimation();
        }

        internal void OnEnemyDying()
        {
            ScoreSignals.Instance.onDeathScoreTaken?.Invoke();

            PushToPool(PoolObjectType.Enemy, gameObject);

        }
        public Transform GetPlayerTransform()
        {
            return PlayerSignals.Instance.onGetPlayerTransform?.Invoke();
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }

    }
}
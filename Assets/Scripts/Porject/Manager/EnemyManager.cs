using Scripts.Signals;
using Interfaces;
using Scripts.Level.Controller;
using Scripts.Level.Data.UnityObject;
using Scripts.Level.Data.ValueObject;
using System;
using System.Collections;
using UnityEngine;
using Script.Signals;

namespace Assets.Scripts.Level.Manager
{
    public class EnemyManager : MonoBehaviour,IManagable
    {
        [SerializeField]
        private EnemyMovementController enemyMovementController;

        [SerializeField]
        private EnemyAnimationController enemyAnimationController;

        [SerializeField]
        private EnemyAttackController enemyAttackController;

        private EnemyData _enemyData;

        private Transform _playerTransform;

        public string DataPath => "Data/Cd_EnemyData";

        private void Awake()
        {
            GetData();

            SetData();
        }

        public  Transform GetPlayerTransform()
        {
             return PlayerSignals.Instance.onGetPlayerTransform?.Invoke();
        }

        private void GetData() => _enemyData = Resources.Load<Cd_EnemyData>(DataPath).EnemyData;


        private void SetData()
        {
            enemyMovementController.SetData(_enemyData.EnemyMovementData);

            enemyAnimationController.SetData(_enemyData.EnemyAnimationData);

            enemyAttackController.SetData(_enemyData.EnemyAttackData);
        }

        public void OnEnable()
        {
            SubscribeEvents();

            ActiveteController();
        }
        public void SubscribeEvents()
        {

        }

        public void UnsubscribeEvents()
        {
           
        }
        public void OnDisable()
        {
            DeactiveController();

            UnsubscribeEvents();
        }
        private void Start()
        {
            TriggerController();
        }
        public void TriggerController()
        {
            //enemyAnimationController.TriggerAction();
        }

        public void ActiveteController()
        {
            enemyMovementController.IsActivating = true;
        }

        public void DeactiveController()
        {
            enemyMovementController.IsActivating = false;
        }

        internal void EnterDetectArea()
        {
            DeactiveController();

            enemyAnimationController.StartAttack();
        }

        internal void ExitDetectArea()
        {
            
       

        }

        internal void OnReadyToAttack()
        {
            enemyAttackController.TriggerToAction();

            enemyMovementController.IsActivating = true;
        }

        internal void OnHitBoomerang()
        {
            ScoreSignals.Instance.onDeathScoreTaken?.Invoke();
        }


    }
}
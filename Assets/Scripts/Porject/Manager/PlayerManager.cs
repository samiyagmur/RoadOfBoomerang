using Scripts.Level.Data.UnityObject;
using Scripts.Signals;
using Interfaces;
using Script.Signals;
using Scripts.Level.Controller;
using Scripts.Level.Data.ValueObject;
using Signals;
using UnityEngine;
using System;

namespace Scripts.Level.Manager
{
    public class PlayerManager : MonoBehaviour, IManagable
    {       
        [SerializeField]
        private PlayerAttackController playerAttackController;

        [SerializeField]
        private PlayerHealthController playerHealthController;


        [SerializeField]
        private PlayerMovementController playerMovementController;

        [SerializeField]
        private PlayerAnimationController playerAnimationController;


        private PlayerData _playerData;

        private float _camDiraction;

        public string DataPath => "Data/Cd_PlayerData";
        private void Awake()
        {
            GetData();

            SetDataToController();
        }

        internal void OnHealtDecrase(float healthValue)
        {
            UISignals.Instance.onHealthDecrase?.Invoke(healthValue);
        }

        internal void PlayerDead()
        {
            
        }

        private void GetData() => _playerData = Resources.Load<Cd_PlayerData>(DataPath).PlayerData;

        private void SetDataToController()
        {
            playerMovementController.SetData(_playerData.PlayerMovementData, _camDiraction);

            playerAnimationController.SetData(_playerData);

            playerHealthController.SetData(_playerData.PlayerHealtData);
        }

        public void OnEnable()
        {
            SubscribeEvents();

            ActiveteController();
        }

        public void SubscribeEvents()
        {
            InputSignals.Instance.onInputTouch += OnInputTouch;

            InputSignals.Instance.onInputReleased += OnInputReleased;

            PlayerSignals.Instance.onGetPlayerTransform += OnGetPlayerTransform;
        }

        public void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputTouch -= OnInputTouch;

            InputSignals.Instance.onInputReleased -= OnInputReleased;

            PlayerSignals.Instance.onGetPlayerTransform -= OnGetPlayerTransform;
        }


        public void OnDisable()
        {
            DeactiveController();

            UnsubscribeEvents();
        }

        private void Start()
        {
            TriggerController();

           _camDiraction = CameraSignals.Instance.onSpawnPlayer.Invoke(gameObject);
        }

        private void OnInputTouch(float diraction,Vector3 joystick)
        {
            playerMovementController.Diraction = diraction;

            playerMovementController.JoystickDirection = joystick;

            playerMovementController.Move();
        }

        private void OnInputReleased()
        {
            
        }
        public void TriggerController()
        {
            playerAnimationController.SetDefaultAnimation();
        }

        public void ActiveteController()
        {
            playerMovementController.IsActivating = true;
            playerAnimationController.IsActivating = true;
        }

        public void DeactiveController()
        {
            playerMovementController.IsActivating = false;
            playerAnimationController.IsActivating = false;
        }

        private Transform OnGetPlayerTransform()
        {
            return transform;
        }

        internal void HitEnemy(GameObject enemyObject)
        {

            playerAttackController.TargetObject = enemyObject;

            playerAttackController.TriggerAction();

        }

        internal void HitDamager(float damage)
        {
            playerHealthController.OnTakeDamage((int)damage);
        }

        public void Death()
        {
            playerAnimationController.PlayDadAnimation();

            playerAnimationController.IsActivating = false;
        }
        internal void HitCoin()
        {
            ScoreSignals.Instance.onScoreTaken?.Invoke();
        }
    }
}
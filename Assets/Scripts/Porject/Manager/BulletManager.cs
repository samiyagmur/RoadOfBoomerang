using Interfaces;
using Script.Signals;
using Scripts.Level.Controller;
using Scripts.Level.Data.UnityObject;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Type;
using Signals;
using System;
using System.Collections;
using Type;
using UnityEngine;

namespace Scripts.Level.Manager
{
    public class BulletManager : MonoBehaviour
    {
        public Transform Target { get ; set ; }

        public float Damage { get; set; }

        [SerializeField]
        private BulletMovementController bulletMovementController;

        private float _timer;

        public const string _dataPath = "Data/Cd_BulletData";

        private BulletData _bulletData;


        private void Awake()
        {
            GetData();

            SetData();
        }

        private void GetData() => _bulletData = Resources.Load<Cd_BulletData>(_dataPath).BulletData;


        private void SetData()
        {
            _timer = 0;

            Damage = _bulletData.damage;

            bulletMovementController.BulletData = _bulletData;
        }

        public void OnEnable()
        {
            SubscribeEvents(); 
            ActiveteController();
        }

        private void SubscribeEvents()
        {

            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onReset -= OnReset;
        }


        public void OnDisable()
        {
            DeactiveController();
            UnsubscribeEvents(); ;
        }

        private void Start()
        {
            TriggerController();
        }

        public void TriggerController()
        {
            bulletMovementController.Target = Target;

            bulletMovementController.TriggerAction();
        }

        public void ActiveteController()
        {
            bulletMovementController.IsActive = true;
        }

        public void DeactiveController()
        {
            bulletMovementController.IsActive = false;

        }
        private void OnReset()
        {
            PushToPool(PoolObjectType.Bullet, gameObject); 
        }

        //private void Update()
        //{
        //    if (!gameObject.activeInHierarchy) return;

        //    _timer += Time.deltaTime;

        //    if (_timer>15)
        //    {
        //        PushToPool(PoolObjectType.Bullet, gameObject);
        //    }
        //}
        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }

    }
}
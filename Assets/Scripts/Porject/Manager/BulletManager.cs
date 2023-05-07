using Interfaces;
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
            ActiveteController();
        }
        public void ActiveteController()
        {
            bulletMovementController.isActivate = true;
        }

        public void DeactiveController()
        {
            bulletMovementController.isActivate = false;

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
            bulletMovementController.Target = Target;

            bulletMovementController.TriggerAction();
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
using Interfaces;
using Scripts.Level.Controller;
using Scripts.Level.Data.UnityObject;
using Scripts.Level.Data.ValueObject;
using Signals;
using System.Collections;
using Type;
using UnityEngine;

namespace Assets.Scripts.Level.Manager
{
    public class BoomerangManager : MonoBehaviour
    {
        public float Damage { get; set; }

        public string DataPath => "Data/Cd_BoomerangData";

        [SerializeField]
        private BoomerangMovementController boomerangMovementController;

        private BoomerangData _boomerangData;
        private float _timer;

        private void Awake()
        {
            GetData();

        }

        private void GetData() => _boomerangData = Resources.Load<Cd_BoomerangData>(DataPath).BoomerangData;

        public void SetData(Transform target)
        {
            Debug.Log(target);

            Damage = _boomerangData.damage;

            boomerangMovementController.SetData(_boomerangData, target);
        }

        public void OnEnable()
        {
            ActiveteController();
        }

        public void ActiveteController()
        {
            boomerangMovementController.IsActivate = true;
        }

        public void DeactiveController()
        {

            boomerangMovementController.IsActivate = false;
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
            boomerangMovementController.TriggerAction();
        }

        private void Update()
        {
            if (!gameObject.activeInHierarchy) return;

            _timer += Time.deltaTime;

            if (_timer > 15)
            {
                PushToPool(PoolObjectType.Boomerang, gameObject);
            }
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}
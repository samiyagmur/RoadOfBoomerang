using Data.UnityObject;
using Interfaces;
using Script.Signals;
using Scripts.Helper.Interfaces;
using Scripts.Level.Controller;
using Scripts.Level.Data.UnityObject;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Type;
using Scripts.Signals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Scripts.Level.Manager
{
    public class SpawnManager : MonoBehaviour,IManagable
    {
        private List<IActivable> _activateable = new List<IActivable>();

        public string DataPath => "Data/Cd_SpawnData";

        public SpawnData SpawnData { get; set; }

        private void Awake()
        {
            GetData();

            InitAllController();
        }

        private void GetData() => SpawnData = Resources.Load<Cd_SpawnData>(DataPath).SpawnData;

        private void InitAllController()
        {
            foreach (SpawnControllerType shopType in Enum.GetValues(typeof(SpawnControllerType)))
            {
                string shopName = "Scripts.Level.Controller." + shopType.ToString() + "Controller";

                IActivable shop = (IActivable)Activator.CreateInstance(System.Type.GetType(shopName), new object[] { this });

                _activateable.Add(shop);
            }

        }

      
        private void OnLevelInitilize()
        {
            Init();
        }
        private void Init() => TriggerController();
        public void OnEnable()
        {
            SubscribeEvents();

            ActiveteController();
        }

        public void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitilize += OnLevelInitilize;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onFail += OnFail;
        }

        public void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitilize -= OnLevelInitilize;
            CoreGameSignals.Instance.onFail -= OnFail;
            CoreGameSignals.Instance.onPlay -= OnPlay;
        }

        public void OnDisable()
        {
            DeactiveController();

            UnsubscribeEvents();

        }

        public void TriggerController()
        {
            foreach (IActivable activates in _activateable)
            {
                activates.TriggerAction();
            }
        }

        public void ActiveteController()
        {
            foreach (IActivable activates in _activateable)
            {
                activates.IsActivating = true;
            }
        }

        public void DeactiveController()
        {
            foreach (IActivable activates in _activateable)
            {
                activates.IsActivating = false;
            }
        }
        private void OnPlay()
        {
            
        }
        private void OnFail()
        {
           
        }

 
    }
}
using Scripts.Level.Controller;
using Scripts.Level.Data.UnityObject;
using Scripts.Level.Data.ValueObject;
using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Manager
{
    public class ExampleManager : MonoBehaviour
    {
        [SerializeField]
        private ExampleController exampleController;
        private ExampleData exampleData;
        private const string _dataPath= "Data/Cd_ExampleData";

        private void Awake()
        {
            GetData();
        }

        private void GetData() => exampleData = Resources.Load<Cd_ExampleData>(_dataPath).exampleData;

        private void OnEnable()
        {
            SubscribeEvents();

            ActiveteController();
        }

        private void SubscribeEvents()
        {
         
        }

        private void UnsubscribeEvents()
        {
            
        }

        private void OnDisable()
        {
            UnsubscribeEvents();

            DeactiveController();
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            TriggerController();
        }

        private void TriggerController()
        {
            throw new NotImplementedException();
        }


        private void ActiveteController()
        {
            throw new NotImplementedException();
        }

        private void DeactiveController()
        {
            throw new NotImplementedException();
        }

    }
}
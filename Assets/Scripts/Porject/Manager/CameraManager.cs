using Cinemachine;
using Controller;
using Data.UnityObject;
using Data.ValueObject;
using Script.Signals;
using Scripts.Signals;
using System;

using System.Collections;
using UnityEngine;

namespace Manager
{
    public class CameraManager : MonoBehaviour
    {

        //[SerializeField]
        //private CameraSettingController cameraSettingController;

        //[SerializeField] 
        //private CinemachineStateDrivenCamera stateDrivenCamera;

        //[SerializeField]
        //private CameraStateController cameraStateController;


        [SerializeField]
        private CinemachineVirtualCamera _virtualCamera;

        private const string _dataPath = "Data/Cd_CameraData";

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
           // cameraSettingController.SetData(GetData().cameraSettingData, stateDrivenCamera);
        }

       // private CameraData GetData() => Resources.Load<Cd_CameraData>(_dataPath).cameraData;

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            //CoreGameSignals.Instance.onPlay += OnPlay;
            //CoreGameSignals.Instance.onFail += OnFail;
            //CoreGameSignals.Instance.onReset += OnReset;

            CameraSignals.Instance.onSpawnPlayer += OnSpawnPlayer;
        }

        

        private void UnsubscribeEvents()
        {
            //CoreGameSignals.Instance.onPlay -= OnPlay;
            //CoreGameSignals.Instance.onFail -= OnFail;
            //CoreGameSignals.Instance.onReset -= OnReset;

            CameraSignals.Instance.onSpawnPlayer -= OnSpawnPlayer;

        }


        private void OnDisable() => UnsubscribeEvents();
        //private void OnPlay() => cameraStateController.WhenPressPlay();
        //private void OnFail() => cameraStateController.WhenCharacterFail();
        //private void OnReset() => cameraStateController.WhenPressReset();


        private float OnSpawnPlayer(GameObject player)
        {
            _virtualCamera.Follow = player.transform;

            return _virtualCamera.transform.rotation.eulerAngles.y;
        }


    }
}
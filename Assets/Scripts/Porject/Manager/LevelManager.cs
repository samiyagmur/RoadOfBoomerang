using Command;
using Controller;
using Data.UnityObject;
using Data.ValueObject;
using Script.Signals;
using Scripts.Helper.Interfaces;
using Scripts.Level.Type;
using Signals;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private Transform levelholder;

        [SerializeField]
        private LevelLoaderCommand levelLoaderCommand;

        [SerializeField]
        private ClearActiveLevelCommand clearActiveLevelCommand;

        private int _levelID;

        private string _dataPath = "Data/Cd_LevelData";

        private LevelData _levelData;

        private void Awake()
        {
            //GetLevelData();
        }

        private void GetLevelData() => _levelData = Resources.Load<Cd_LevelData>(_dataPath).LevelData[_levelID];

        private void OnEnable()
        {
            SubscribeEvents();

        }

        private void SubscribeEvents()
        {

            CoreGameSignals.Instance.onLevelInitilize += OnLevelInitilize;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onFail += OnFail;
            CoreGameSignals.Instance.onReset += OnReset;

        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitilize -= OnLevelInitilize;
            CoreGameSignals.Instance.onFail -= OnFail;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -=OnReset;
        }
        private void OnDisable()
        {

            UnsubscribeEvents();
        }

        private void Start()
        {
            CoreGameSignals.Instance.onLevelInitilize?.Invoke();
        }

        private void OnLevelInitilize()
        {
           levelLoaderCommand.InsitializeLevel(_levelID, levelholder);
        }
        private void OnPlay()
        {

        }
        private void OnFail()
        {
            clearActiveLevelCommand.ClearActiveLevel(levelholder);

            CoreGameSignals.Instance.onReset?.Invoke();
        }

        private void OnReset()
        {
            SaveLoadSignals.Instance.onSave?.Invoke();

        }
    }
}
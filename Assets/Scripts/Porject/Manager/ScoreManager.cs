using Data.UnityObject;
using Data.ValueObject;
using Interfaces;
using Manager;
using Script.Signals;
using System;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private ISaver _saver;
        private ILoader _loader;
        private string _dataPath = "Data/Cd_ScoreData";
        private ScoreData _scoreData;

        private void Awake()
        {
            GetData();
            SetInstance();
            InitData(); 
        }

        private void SetInstance()
        {
           _saver = new SaveLoadManager();
           _loader = new SaveLoadManager();
        }

        private void InitData()
        {   
            UISignals.Instance.onPrintLastGoldScore?.Invoke(_scoreData.LastGoldScore);
            UISignals.Instance.onPrintLastDeathScore?.Invoke(_scoreData.LastDeathScore);
        }

        public void GetData()
        {
            _scoreData = Resources.Load<Cd_ScoreData>(_dataPath).ScoreData;
        }

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            ScoreSignals.Instance.onScoreTaken += OnScoreTaken;
            ScoreSignals.Instance.onDeathScoreTaken += OnDeathScoreTaken;
        }

        private void UnsubscribeEvents()
        {
            ScoreSignals.Instance.onScoreTaken -= OnScoreTaken;
            ScoreSignals.Instance.onDeathScoreTaken -= OnDeathScoreTaken;
        }

   

        private void OnDisable() => UnsubscribeEvents();

        private void OnScoreTaken()
        {
            _scoreData.LastGoldScore++;

            Debug.Log(_scoreData.LastGoldScore);

            UISignals.Instance.onPrintLastGoldScore?.Invoke(_scoreData.LastGoldScore);
        }
        private void OnDeathScoreTaken()
        {
            _scoreData.LastDeathScore++;

            UISignals.Instance.onPrintLastDeathScore?.Invoke(_scoreData.LastDeathScore);
        }

        private void Save()
        {
            _saver.UpdateSave(_scoreData);
        }

        private void Load()
        {
            _scoreData = _loader.UpdateLoad<ScoreData>();

            InitData();

        }

    }
}
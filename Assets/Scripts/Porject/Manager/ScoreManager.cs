﻿using Data.UnityObject;
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

        private string _dataPath = "Data/Cd_ScoreData";

        private ScoreData _scoreData;

        private void Awake()
        {
            GetData();
            InitData(); 
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

            UISignals.Instance.onPrintLastGoldScore?.Invoke(_scoreData.LastGoldScore);
        }

        private void OnDeathScoreTaken()
        {
            _scoreData.LastDeathScore++;

            UISignals.Instance.onPrintLastDeathScore?.Invoke(_scoreData.LastDeathScore);
        }
    }
}
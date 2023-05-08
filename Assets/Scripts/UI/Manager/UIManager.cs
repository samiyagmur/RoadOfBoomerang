using Controller;
using Script.Signals;
using Type;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private UIPanelController uIPanelController;

        [SerializeField]
        private LevelPanelController levelPanelController;

        [SerializeField]
        private FailPanelController failPanelController;

        private int _lastDeathScore;

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onPrintLastGoldScore += OnInitLastGoldScore;
            UISignals.Instance.onHealthDecrase += OnHealthDecrase;
            UISignals.Instance.onPrintLastDeathScore += OnPrintLastDeathScore;

            CoreGameSignals.Instance.onLevelInitilize += OnLevelInitilize;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onFail += OnFail;
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onPrintLastGoldScore -= OnInitLastGoldScore;
            UISignals.Instance.onHealthDecrase -= OnHealthDecrase;
            UISignals.Instance.onPrintLastDeathScore -= OnPrintLastDeathScore;

            CoreGameSignals.Instance.onLevelInitilize -= OnLevelInitilize;
            CoreGameSignals.Instance.onFail -= OnFail;
            CoreGameSignals.Instance.onPlay -= OnPlay;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void OnOpenPanel(UIPanelType panelType) => uIPanelController.ChangePanel(panelType, true);

        internal void OnClosePanel(UIPanelType panelType) => uIPanelController.ChangePanel(panelType, false);

        private void OnLevelInitilize()
        {
            OnOpenPanel(UIPanelType.StartPanel);
        }

        internal void ChangePanelStatusOnPlay()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        private void OnPlay()
        {
            OnClosePanel(UIPanelType.StartPanel);

            OnOpenPanel(UIPanelType.LevelPanel);
        }

        public void ChangePanelStatusOnStartAsSetting(UIPanelType uIPanelType)
        {
            OnOpenPanel(uIPanelType);

            OnClosePanel(UIPanelType.StartPanel);
        }

        private void OnFail()
        {
            failPanelController.SetDeathScore(_lastDeathScore);

            OnOpenPanel(UIPanelType.FailPanel);
        }

        internal void ChangePanelStatusOnPressTryAgain(UIPanelType uIPanelType)
        {
            OnClosePanel(uIPanelType);

            OnOpenPanel(UIPanelType.StartPanel);

            CoreGameSignals.Instance.onLevelInitilize?.Invoke();

            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        private void OnHealthDecrase(float health)
        {
            levelPanelController.PrintHealth(health);
        }

        internal void OnInitLastGoldScore(int value)
        {
            levelPanelController.InitGoldScore(value);
        }

        private void OnPrintLastDeathScore(int value)
        {
            _lastDeathScore = value;
            levelPanelController.InitDeathScore(value);
        }
    }
}
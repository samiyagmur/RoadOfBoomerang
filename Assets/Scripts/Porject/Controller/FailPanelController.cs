using Managers;
using TMPro;
using Type;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class FailPanelController : MonoBehaviour
    {
        [SerializeField]
        private UIManager manager;

        [SerializeField]
        private TextMeshProUGUI lastDeathScore;

        [SerializeField]
        private Button tryAgainButton;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            InitButton();
        }

        internal void SetDeathScore(int value)
        {
            lastDeathScore.text = value.ToString();
        }

        private void InitButton()
        {
            tryAgainButton.onClick.AddListener(delegate { ArangePanelStatus(UIPanelType.FailPanel); });
        }

        private void ArangePanelStatus(UIPanelType uIPanelType)
        {
            Debug.Log("sssss");
            manager.ChangePanelStatusOnPressTryAgain(uIPanelType);
        }
    }
}
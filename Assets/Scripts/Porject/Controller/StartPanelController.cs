using Managers;
using Type;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class StartPanelController : MonoBehaviour
    {
        [SerializeField]
        private UIManager manager;

        [SerializeField]
        private Button startButton;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            InitButton();
        }

        private void InitButton()
        {
            startButton.onClick.AddListener(delegate { ArangeStartPanelStatus(); });
        }

        private void ArangeStartPanelStatus()
        {
            manager.ChangePanelStatusOnPlay();
        }

        private void ArangePanelStatus(UIPanelType uIPanelType)
        {
            manager.ChangePanelStatusOnStartAsSetting(uIPanelType);
        }
    }
}
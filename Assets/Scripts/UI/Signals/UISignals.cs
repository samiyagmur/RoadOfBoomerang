using Extantions;
using Type;
using UnityEngine.Events;

namespace Script.Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<UIPanelType> onOpenPanel = delegate { };

        public UnityAction<UIPanelType> onClosePanel = delegate { };

        public UnityAction<int> onPrintLastGoldScore = delegate { };

        public UnityAction<float> onHealthDecrase = delegate { };

        internal UnityAction<int> onPrintLastDeathScore = delegate { };
    }
}
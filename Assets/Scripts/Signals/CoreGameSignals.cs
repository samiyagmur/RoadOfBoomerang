using Extantions;
using UnityEngine.Events;

namespace Script.Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onLevelInitilize = delegate { };

        public UnityAction onPlay = delegate { };

        public UnityAction onFail = delegate { };

        public UnityAction onReset = delegate { };
    }
}
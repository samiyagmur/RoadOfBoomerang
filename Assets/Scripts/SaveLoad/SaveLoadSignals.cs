using Extantions;
using UnityEngine.Events;

namespace Signals
{
    public class SaveLoadSignals : MonoSingleton<SaveLoadSignals>
    {
        public UnityAction onSave = delegate { };

        public UnityAction onLoad = delegate { };
    }
}
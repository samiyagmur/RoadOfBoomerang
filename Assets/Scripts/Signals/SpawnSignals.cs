using Extantions;
using UnityEngine.Events;

namespace Scripts.Signals
{
    public class SpawnSignals : MonoSingleton<SpawnSignals>
    {
        public UnityAction onSetCollectableSpawnData = delegate { };
    }
}
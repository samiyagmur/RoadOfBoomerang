using Extantions;
using UnityEngine.Events;

namespace Script.Signals
{
    public class AudioSignals : MonoSingleton<AudioSignals>
    {
        public UnityAction<float> onUpdateSoundVolume = delegate { };

        public UnityAction<bool> onUpdateSoundStatus = delegate { };
    }
}
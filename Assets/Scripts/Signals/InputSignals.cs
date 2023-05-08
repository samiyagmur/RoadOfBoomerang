using Extantions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction<float, Vector3> onInputTouch = delegate { };

        public UnityAction onInputReleased = delegate { };
    }
}
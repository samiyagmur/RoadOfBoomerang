using Extantions;
using UnityEngine.Events;

namespace Script.Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
        public UnityAction onScoreTaken = delegate { };

        public UnityAction onDeathScoreTaken = delegate { };
    }
}
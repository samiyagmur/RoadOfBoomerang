using Extantions;
using System;
using UnityEngine;

namespace Scripts.Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public Func<Transform> onGetPlayerTransform = delegate { return null; };
    }
}
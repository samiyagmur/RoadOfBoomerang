using Extantions;
using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public Func<Transform> onGetPlayerTransform = delegate { return null; };
    }
}
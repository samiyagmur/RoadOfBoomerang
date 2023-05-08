using Extantions;
using System;
using UnityEngine;

namespace Scripts.Signals
{
    public class CameraSignals : MonoSingleton<CameraSignals>
    {
        public Func<GameObject, float> onSpawnPlayer = delegate { return 0; };
    }
}
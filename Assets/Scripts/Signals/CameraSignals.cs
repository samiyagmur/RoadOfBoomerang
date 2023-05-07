using Extantions;
using Script.Signals;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Signals
{
    public class CameraSignals : MonoSingleton<CameraSignals>
    {
        public Func<GameObject,float> onSpawnPlayer = delegate { return 0; };

    }
}
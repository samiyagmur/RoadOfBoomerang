using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class CollectableSpawnData
    {
        public int spawnLimit;

        public GameObject collectableSpawnZone;

    }
}
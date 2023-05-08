using System;
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
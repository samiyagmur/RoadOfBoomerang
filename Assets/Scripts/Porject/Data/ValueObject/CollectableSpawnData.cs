using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class CollectableSpawnData
    {
        public int spawnCount;

        public int spawnLimit;

        public float spawnRange;

        public GameObject collectableSpawnZone;

    }
}
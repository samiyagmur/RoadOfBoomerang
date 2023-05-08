using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class EnemySpawnData
    {
        public int spawnLimit;

        public float spawnRange;

        public GameObject enemySpawnZone;
    }
}
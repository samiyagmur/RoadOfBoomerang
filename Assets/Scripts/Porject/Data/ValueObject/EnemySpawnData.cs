using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class EnemySpawnData
    {
        public int spawnLimit;

        public int spawnRange;

        public GameObject enemySpawnZone;
    }
}
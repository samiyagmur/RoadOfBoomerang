using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class SpawnData 
    {
        public EnemySpawnData enemySpawnData;

        public PlayerSpawnData playerSpawnData;

        public CollectableSpawnData collectableSpawnData;

    }
}


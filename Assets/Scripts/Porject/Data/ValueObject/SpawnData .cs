using System;

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
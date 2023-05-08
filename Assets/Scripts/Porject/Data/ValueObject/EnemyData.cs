using System;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class EnemyData
    {
        public EnemyMovementData EnemyMovementData;

        public EnemyAnimationData EnemyAnimationData;

        public EnemyAttackData EnemyAttackData;
    }
}
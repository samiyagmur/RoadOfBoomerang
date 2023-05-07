using System;
using System.Collections;
using UnityEngine;

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
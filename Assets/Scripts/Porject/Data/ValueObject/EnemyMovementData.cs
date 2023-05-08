using System;
using UnityEngine;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class EnemyMovementData
    {
        [Range(1f, 5f)]
        public float speed;
    }
}
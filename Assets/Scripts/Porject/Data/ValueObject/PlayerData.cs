using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class PlayerData 
    {
        public PlayerAnimationData PlayerAnimationData;

        public PlayerMovementData PlayerMovementData;

        public PlayerHealtData PlayerHealtData;

        public PlayerAttackData PlayerAttackData;
    }
}
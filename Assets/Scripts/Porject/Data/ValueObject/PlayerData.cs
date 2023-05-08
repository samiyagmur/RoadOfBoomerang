using System;

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
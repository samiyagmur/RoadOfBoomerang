using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class BoomerangData 
    {
        public int damage;

        public int speed;

        public int rotations;

        public float duration;
    }
}
﻿using Scripts.Level.Data.ValueObject;
using UnityEngine;

namespace Scripts.Level.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_BulletData", menuName = "Data/BulletData")]
    public class Cd_BulletData : ScriptableObject
    {
        public BulletData BulletData;
    }
}
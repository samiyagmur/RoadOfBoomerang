using Scripts.Level.Data.ValueObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Level.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_BulletData", menuName = "Data/BulletData")]
    public class Cd_BulletData : ScriptableObject
    {
        public BulletData BulletData;
    }
}
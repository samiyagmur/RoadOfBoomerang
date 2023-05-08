using Scripts.Level.Data.ValueObject;
using UnityEngine;

namespace Scripts.Level.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_EnemyData", menuName = "Data/EnemyData")]
    public class Cd_EnemyData : ScriptableObject
    {
        public EnemyData EnemyData;
    }
}
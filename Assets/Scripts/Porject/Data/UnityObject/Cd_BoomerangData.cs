using Scripts.Level.Data.ValueObject;
using UnityEngine;

namespace Scripts.Level.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_BoomerangData", menuName = "Data/BoomerangData")]
    public class Cd_BoomerangData : ScriptableObject
    {
        public BoomerangData BoomerangData;
    }
}
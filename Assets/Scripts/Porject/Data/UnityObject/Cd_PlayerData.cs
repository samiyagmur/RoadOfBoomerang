using Scripts.Level.Data.ValueObject;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_PlayerData", menuName = "Data/PlayerData")]
    public class Cd_PlayerData : ScriptableObject
    {
        public PlayerData PlayerData;
    }
}
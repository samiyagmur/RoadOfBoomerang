using Scripts.Level.Data.ValueObject;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_ExampleData", menuName = "Data/ExampleData")]
    public  class Cd_ExampleData:ScriptableObject
    {
        public ExampleData exampleData;
    }
}
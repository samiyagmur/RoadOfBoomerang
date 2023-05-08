using System;
using UnityEngine;

namespace Scripts.SaveLoad
{
    [Serializable]
    public class DataContainer
    {
        public int _id;

        public string _key;

        public ScriptableObject scriptableObject;
    }
}
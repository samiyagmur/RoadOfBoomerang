using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.SaveLoad
{
    [Serializable]
    public class DataContainer
    {
        public  int _id;

        public  string _key;

        public  ScriptableObject scriptableObject;
    }

}
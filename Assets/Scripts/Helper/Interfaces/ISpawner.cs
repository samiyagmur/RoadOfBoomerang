using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Helper.Interfaces
{
    public interface ISpawner 
    {

        bool IsActivating { get; set; }

        void TriggerAction();

        void Spawn();
        void Reset();
    }
}
using System.Collections;
using UnityEngine;

namespace Scripts.Helper.Interfaces
{
    public interface IActivable 
    {
        bool IsActivating { get; set; }

        void TriggerAction();

        void StartAction();
    }
}
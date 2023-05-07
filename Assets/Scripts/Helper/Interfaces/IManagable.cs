using Type;
using UnityEngine;

namespace Interfaces
{
    public interface IManagable
    {
        string DataPath { get; }

        void OnEnable();

        void SubscribeEvents();

        void UnsubscribeEvents();

        void OnDisable();

        void TriggerController();

        void ActiveteController();

        void DeactiveController();
    }
}
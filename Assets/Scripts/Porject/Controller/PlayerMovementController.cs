using Data.ValueObject;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PlayerMovementController :MonoBehaviour
    {
        public bool IsActivating { get; set; }

        private float _diraction;

        private Vector3 _joystickDirection;
        public float Diraction { get => _diraction; set => _diraction = value; }
        public Vector3 JoystickDirection { get => _joystickDirection; set => _joystickDirection = value; }



        private PlayerMovementData _playerMovementData;

        [SerializeField]
        private new Rigidbody rigidbody;

        internal void SetData(PlayerMovementData playerMovementData, float camDiraction)
        {
            _playerMovementData = playerMovementData;
        }
        internal void Move()
        {
            if (!IsActivating) return;

            Quaternion targetRotation = Quaternion.LookRotation(JoystickDirection);

            rigidbody.MoveRotation(Quaternion.Slerp(rigidbody.rotation, targetRotation, _playerMovementData.TurnSpeed * Time.fixedDeltaTime));

            rigidbody.velocity = JoystickDirection.normalized * _playerMovementData.Speed ;
        }

    }
}
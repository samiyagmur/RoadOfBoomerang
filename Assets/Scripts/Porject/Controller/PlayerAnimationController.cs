using Data.ValueObject;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using System;
using System.Collections;
using UnityEngine;
using Scripts.Extetions;
using Scripts.Level.Manager;
using Scripts.Level.Type;

namespace Scripts.Level.Controller
{
    public class PlayerAnimationController : MonoBehaviour
    {
        public bool IsActive { get; set; }

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private new Rigidbody rigidbody;

        [SerializeField]
        private PlayerManager playerManager;

        private PlayerData _playerData;

        internal void SetData(PlayerData playerData)
        {
            _playerData = playerData;
        }
        public void OnDeadPlayer()
        {
            playerManager.OnDeadPlayer();
        }
        internal void SetDefaultAnimation()
        {
            ChangeAnimationType(PlayerAnimationType.Other);
        }
        internal void PlayDadAnimation()
        {
            ChangeAnimationType(PlayerAnimationType.Dead);
        }

        public void ChangeAnimationType(PlayerAnimationType playeranimationtype)
        {
            animator.Play(playeranimationtype.ToString());
        }
        private void FixedUpdate()
        {
            PlayAnimation();
        }
    
        internal void PlayAnimation()
        {
            if (!IsActive) return;

            float _currentSpeed = rigidbody.velocity.magnitude;

            float clampedValue = SelfExtetions.Map(_currentSpeed, 0, _playerData.PlayerMovementData.Speed, 0, 1f);

            animator.SetFloat("Horizontal", clampedValue);
        }
    }
}

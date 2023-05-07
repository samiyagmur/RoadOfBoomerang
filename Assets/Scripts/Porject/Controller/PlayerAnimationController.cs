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
        public bool IsActivating { get; set; }

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private new Rigidbody rigidbody;

        [SerializeField]
        private PlayerManager playerManager;

        private PlayerData _playerData;

        private bool isDead;

        private bool isAtack;

        private PlayerAnimationType _playerAnimationType;

        internal void SetData(PlayerData playerData)
        {
            _playerData = playerData;
        }

        internal void PlayDadAnimation()
        {
            ChangeAnimationType(PlayerAnimationType.Dead);
        }
        internal void SetDefaultAnimation()
        {
            ChangeAnimationType(PlayerAnimationType.Other);
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
            if (!IsActivating) return;


            float _currentSpeed = rigidbody.velocity.magnitude;

            float clampedValue = SelfExtetions.Map(_currentSpeed, 0, _playerData.PlayerMovementData.Speed, 0, 1f);

            animator.SetFloat("Horizontal", clampedValue);
          
           
        }

    }
}

using Data.ValueObject;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Level.Controller
{
    public class PlayerHealthController : MonoBehaviour
    {
        [SerializeField]
        private PlayerManager playerManager;

        private float _health;
        private float _maxHealt;

        internal void SetData(PlayerHealtData playerHealtData)
        {
            _maxHealt = playerHealtData.MaxHealth;
            _health = _maxHealt;
        }

        public void OnTakeDamage(int damage)
        {
            if (_health >= 0)
                _health -= damage;
            else
            {
                playerManager.PlayerDead();
            }

            OnHealthUpdate(_health);
        }

        private void OnHealthUpdate(float healthValue)
        {
            playerManager.OnHealtDecrase(healthValue);
        }
    }
}
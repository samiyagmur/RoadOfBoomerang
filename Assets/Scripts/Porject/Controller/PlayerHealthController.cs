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
        private int _deadHealt;
        private int _maxHealt;
        private int _damage;

        internal void SetData(PlayerHealtData playerHealtData)
        {
            _maxHealt = playerHealtData.MaxHealth;
            _health = _maxHealt;
      
        }

        internal void SetDamage(int damage)
        {
            _damage = damage;
            _deadHealt = _maxHealt / damage;

        }
        public void OnTakeDamage()
        {
            if (_health < _deadHealt)
            {

                _health -= _damage;

                OnHealthUpdate(_health);
            }
            else
            {
                Debug.Log(playerManager);
                playerManager.PlayerDead();
            }
        }

        private void OnHealthUpdate(float healthValue)
        {
            playerManager.OnHealtDecrase(healthValue);
        }

    }
}
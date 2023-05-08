using Scripts.Helper.Interfaces;
using Scripts.Level.Manager;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PlayerDetectController : MonoBehaviour
    {
        [SerializeField]
        private PlayerManager playerManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEnemyable enemy))
            {
                playerManager.HitEnemy(enemy.GetHitEnemy());
            }
        }
    }
}
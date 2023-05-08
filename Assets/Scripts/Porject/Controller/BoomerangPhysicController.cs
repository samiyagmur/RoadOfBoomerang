using Assets.Scripts.Level.Manager;
using Scripts.Helper.Interfaces;
using Scripts.Level.Manager;
using Signals;
using System.Collections;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class BoomerangPhysicController : MonoBehaviour
    {
        [SerializeField]
        private BoomerangManager boomerangManager;

        private void OnTriggerEnter(Collider other)
        {
            PushToPool(PoolObjectType.Bullet, transform.parent.gameObject);
        }

        public float TakeDamage()
        {
            return boomerangManager.Damage;
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }

    }
}
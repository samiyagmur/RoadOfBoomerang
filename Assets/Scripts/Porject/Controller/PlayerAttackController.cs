using Assets.Scripts.Level.Manager;
using Data.ValueObject;
using Interfaces;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using Signals;
using System;
using System.Collections;
using System.Threading.Tasks;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PlayerAttackController : MonoBehaviour, IPullObject
    {
        [SerializeField]
        private GameObject spawnPointForBoomerang;

        private float _timer;

        public bool IsActive { get; set; }

        public  GameObject TargetObject { get; set; }

        public void TriggerAction()
        {
            Attack();
        }

        private void Attack()
        {
            if (!IsActive) return;

            GameObject boomerang = PullFromPool(PoolObjectType.Boomerang);

            Vector3 HorizontalOffset = new Vector3(0, 1, 0);

            boomerang.transform.position = transform.position + HorizontalOffset;

            if (boomerang.TryGetComponent(out BoomerangManager boomerangManager))
            {
                boomerangManager.SetData(TargetObject.transform);
            }
        }
        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }
    }
}
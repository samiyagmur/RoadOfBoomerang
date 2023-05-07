using Assets.Scripts.Level.Manager;
using Data.ValueObject;
using Interfaces;
using Scripts.Helper.Interfaces;
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Manager;
using Signals;
using System;
using System.Collections;
using Type;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PlayerAttackController : MonoBehaviour, IPullObject
    {
        [SerializeField]
        private GameObject spawnPointForBoomerang;

        public bool IsActivating { get; set; }

        public  GameObject TargetObject { get; set; }

        public void StartAction()
        {

        }

        public void TriggerAction()
        {

           // Attack();

            if (!IsActivating) return;

        }

        private void Attack()
        {
            GameObject boomerang = PullFromPool(PoolObjectType.Boomerang);


            boomerang.transform.position = transform.position+new Vector3(0,1,0);

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
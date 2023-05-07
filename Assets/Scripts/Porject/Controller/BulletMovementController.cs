using Scripts.Level.Data.ValueObject;
using Scripts.Level.Type;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class BulletMovementController : MonoBehaviour
    {
        public bool isActivate { get; set; }

        public BulletData BulletData { get ; set ; }

        public Transform Target { get; set ; }

        [SerializeField]
        private Rigidbody bulletRigdbody;

        public void TriggerAction()
        {
            MoveAsFireBal();

            if (isActivate) return;
        }

        private void MoveAsFireBal()
        {

            bulletRigdbody.AddForce(Target.forward * BulletData.Speed,ForceMode.Impulse);
        }

    }
}
using Scripts.Level.Data.ValueObject;
using Scripts.Level.Type;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class BulletMovementController : MonoBehaviour
    {
        public bool IsActive { get; set; }

        public BulletData BulletData { get ; set ; }

        public Transform Target { get; set ; }

        [SerializeField]
        private Rigidbody bulletRigdbody;

        public void TriggerAction()
        {
            if (!IsActive) return;

            MoveAsFireBal();
        }

        private void MoveAsFireBal()
        {

            bulletRigdbody.AddForce(Target.forward * BulletData.Speed,ForceMode.Impulse);
        }

    }
}
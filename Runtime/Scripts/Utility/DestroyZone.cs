using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class DestroyZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var d = other.gameObject.GetComponent<IDestroyable>();
            if (d == null)
            {
                return;
            }
            d.CustomDestroy();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var d = collision.gameObject.GetComponent<IDestroyable>();
            if (d == null)
            {
                return;
            }
            d.CustomDestroy();
        }
    }
}

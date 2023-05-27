using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class RandomPointInBoxCollider : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider _boxCollider;

        private void Start()
        {
            if (_boxCollider != null)
            {
                _boxCollider = GetComponent<BoxCollider>();
            }

            if (_boxCollider == null)
            {
                Debug.LogError("BoxCollider is not assigned!");
                return;
            }
        }

        public Vector3 GetRandomPointInBoxCollider()
        {
            Vector3 result = Vector3.zero;
            Vector3 boundsMin = _boxCollider.bounds.min;
            Vector3 boundsMax = _boxCollider.bounds.max;

            float x = Random.Range(boundsMin.x, boundsMax.x);
            float y = Random.Range(boundsMin.y, boundsMax.y);
            float z = Random.Range(boundsMin.z, boundsMax.z);
            result.x = x;
            result.y = y;
            result.z = z;
            return result;        }
    }
}

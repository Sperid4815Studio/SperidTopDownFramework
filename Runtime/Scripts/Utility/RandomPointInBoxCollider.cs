using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public static class RandomPointInBoxCollider
    {
        public static Vector3 GetRandomPointInBoxCollider(BoxCollider collider)
        {
            Vector3 result = Vector3.zero;
            Vector3 boundsMin = collider.bounds.min;
            Vector3 boundsMax = collider.bounds.max;

            float x = Random.Range(boundsMin.x, boundsMax.x);
            float y = Random.Range(boundsMin.y, boundsMax.y);
            float z = Random.Range(boundsMin.z, boundsMax.z);
            result.x = x;
            result.y = y;
            result.z = z;
            return result;        }
    }
}

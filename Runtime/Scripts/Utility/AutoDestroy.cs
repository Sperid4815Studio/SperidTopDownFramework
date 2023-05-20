using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class AutoDestroy : MonoBehaviour
    {
        [SerializeField]
        private float _time;


        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_time);
            GameObject.Destroy(gameObject);
        }
    }
}

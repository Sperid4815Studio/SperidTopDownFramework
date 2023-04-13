using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class CanvasElement : MonoBehaviour
    {
        [SerializeField]
        private string _id;

        public string Id { get => _id; }

        public void Reset()
        {
            _id = gameObject.name;
        }
    }
}

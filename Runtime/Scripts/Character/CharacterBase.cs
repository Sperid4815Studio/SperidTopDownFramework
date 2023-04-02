using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public abstract class CharacterBase : MonoBehaviour
    {
        [SerializeField]
        protected float _moveSpeed;

        protected Vector3 _moveDirection;

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        protected virtual void Start()
        {
        
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        protected virtual void Update()
        {

        }
    }
}

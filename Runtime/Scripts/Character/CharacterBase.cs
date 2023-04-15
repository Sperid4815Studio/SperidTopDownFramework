using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public abstract class CharacterBase : MonoBehaviour
    {
        [SerializeField]
        protected float MoveSpeed;

        protected Vector3 MoveDirection;

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

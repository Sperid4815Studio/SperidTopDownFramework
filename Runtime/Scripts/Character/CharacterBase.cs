using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public abstract class CharacterBase : MonoBehaviour,IDestroyable
    {
        [SerializeField]
        protected float _moveSpeed;

        [SerializeField]
        private int _hp;

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

        public void CustomDestroy()
        {
            Destroy(gameObject);
        }
    }
}

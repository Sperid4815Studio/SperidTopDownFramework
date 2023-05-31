using System;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public abstract class CharacterBase : MonoBehaviour,IDestroyable<CharacterBase>
    {
        [SerializeField]
        protected float _moveSpeed;

        [SerializeField]
        private int _hp;

        protected Vector3 MoveDirection;

        public event Action<CharacterBase> OnCustomDestroy;

        public int Hp { get => _hp; protected set { _hp = value; } }

        public float MoveSpeed { get => _moveSpeed; protected set { _moveSpeed = value; } }


        public virtual void CustomDestroy()
        {
            OnCustomDestroy?.Invoke(this);
            Destroy(gameObject);
        }

        public virtual void ApplyDamage(int value)
        {
            Hp -= value;
            if (Hp <= 0)
            {
                CustomDestroy();
            }
        }

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

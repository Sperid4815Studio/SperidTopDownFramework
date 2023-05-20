using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class ProjectileBase : MonoBehaviour,IDestroyable
    {
        public enum ProjectileState
        {
            None,
            Play,
            Stop,
            Pause
        }

        [SerializeField]
        private float _speed;

        [SerializeField]
        private int _damage;

        [SerializeField]
        private int _reflectCount;

        [SerializeField]
        private ProjectileState _state;

        private Vector3 _direction;

        public float Speed { get => _speed; set => _speed = value; }
        public int Damage { get => _damage; set => _damage = value; }
        public int ReflectCount { get => _reflectCount; set => _reflectCount = value; }
        public Vector3 Direction { get => _direction; set => _direction = value; }
        public ProjectileState State { get => _state; protected set => _state = value; }

        public event System.Action OnDestroy;
        
        public virtual void Play()
        {
            State = ProjectileState.Play;
        }

        public virtual void Stop()
        {
            State = ProjectileState.Stop;
        }

        public virtual void Pause()
        {
            State = ProjectileState.Pause;
        }

        public void CustomDestroy()
        {
            OnDestroy?.Invoke();
            Destroy(gameObject);
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {
        
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if(State != ProjectileState.Play)
            {
                return;
            }

            transform.Translate(_direction * Speed * Time.deltaTime);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Try find instance.
                    _instance = GameObject.FindObjectOfType<T>();

                    // Create new instance.
                    if (_instance == null)
                    {
                        var ob = new GameObject("SingletonBehaviour");
                        _instance = ob.AddComponent<T>();
                    }

                    GameObject.DontDestroyOnLoad(_instance);
                }

                return _instance;
            }
        }

        public static bool IsAlive()
        {
            return _instance != null;
        }

        public bool IsInitialize { get; protected set; } = false;

        public virtual void Initialize()
        {
            IsInitialize = true;
        }

        public virtual void Destroy()
        {
            IsInitialize = false;
            Destroy(this);
        }

    }
}

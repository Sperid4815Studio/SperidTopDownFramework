using System;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class CanvasBase : MonoBehaviour
    {
        private Dictionary<string, CanvasElement> _elements;

        public static event Action<CanvasBase> OnCanvasAwake;
        public static event Action<CanvasBase> OnCanvasDestroy;

        protected CanvasElement GetElement(string id)
        {
            return !_elements.ContainsKey(id) ? null : _elements[id];
        }

        protected T GetElementComponent<T>(string id, bool includeChild = false) where T : Component
        {
            if (!_elements.ContainsKey(id))
            {
                return null;
            }
            else
            {
                if (includeChild)
                {
                    var c = _elements[id].gameObject.GetComponent<T>();
                    if (c == null)
                    {
                        c = _elements[id].gameObject.GetComponentInChildren<T>(true);
                    }

                    return c;
                }
                else
                {
                    return _elements[id].gameObject.GetComponent<T>();
                }

            }

        }

        protected virtual void Awake()
        {
            _elements = new Dictionary<string, CanvasElement>();

            foreach (var e in GetComponentsInChildren<CanvasElement>(true))
            {
                Debug.Assert(_elements.ContainsKey(e.Id) == false);
                _elements[e.Id] = e;
            }

            OnCanvasAwake?.Invoke(this);
        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {

        }

        protected virtual void OnDestroy()
        {
            _elements.Clear();
            _elements = null;
            OnCanvasDestroy?.Invoke(this);
        }
    }
}

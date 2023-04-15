using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class CanvasManager : SingletonBehaviour<CanvasManager>
    {
        private UnityEngine.EventSystems.EventSystem _eventSystem;
        private List<CanvasBase> _registerCanvases;

        public override void Initialize()
        {
            LoadEventSystem();
            _registerCanvases = new List<CanvasBase>();

            CanvasBase.OnCanvasAwake += Register;
            CanvasBase.OnCanvasDestroy += UnRegister;

            name = "CanvasManager";
            base.Initialize();
        }

        public T GetCanvas<T>()
            where T : CanvasBase
        {
            return _registerCanvases.FirstOrDefault(t => t is T) as T;
        }

        private void Register(CanvasBase canvas)
        {
            Debug.Assert(_registerCanvases != null);
            _registerCanvases?.Add(canvas);
        }

        private void UnRegister(CanvasBase canvas)
        {
            Debug.Assert(_registerCanvases != null);
            _registerCanvases?.Remove(canvas);
        }

        private void LoadEventSystem()
        {
            var handle = Resources.Load<GameObject>("EventSystem");
            _eventSystem = Instantiate(handle).GetComponent<UnityEngine.EventSystems.EventSystem>();
            _eventSystem.gameObject.transform.SetParent(transform);
        }
    }
}

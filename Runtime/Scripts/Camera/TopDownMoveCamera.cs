using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class TopDownCamera : CameraBase
    {
        [System.Serializable]
        public struct OffsetParameter
        {
            public Vector3 Position;

            public Vector3 Rotation;
        }

        [SerializeField]
        private readonly List<OffsetParameter> _offsets = null;

        [SerializeField]
        private GameObject _followTarget;

        public int CurrentOffsetIndex { get; private set; }

        public void SetFollowTarget(GameObject target)
        {
            _followTarget = target;
        }

        public void SetOffset(int index)
        {
            CurrentOffsetIndex = index;
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
            InternalUpdate();
        }

        [ContextMenu("Internal Update")]
        private void InternalUpdate()
        {
            if (_followTarget == null)
            {
                return;
            }

            transform.position = _followTarget.transform.position + _offsets[CurrentOffsetIndex].Position;
            transform.rotation = Quaternion.Euler(_offsets[CurrentOffsetIndex].Rotation);
        }
    }
}

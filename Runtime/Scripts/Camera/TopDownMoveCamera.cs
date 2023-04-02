using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class TopDownCamera : CameraBase
    {
        [System.Serializable]
        public struct OffsetParametor
        {
            public Vector3 _position;

            public Vector3 _rotation;
        }

        [SerializeField]
        private List<OffsetParametor> _offsets;

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

            transform.position = _followTarget.transform.position + _offsets[CurrentOffsetIndex]._position;
            transform.rotation = Quaternion.Euler(_offsets[CurrentOffsetIndex]._rotation);
        }
    }
}

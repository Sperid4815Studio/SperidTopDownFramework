using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class CanvasElement : MonoBehaviour
    {
        [SerializeField]
        private string _id;

        public string Id => _id;

        public void Reset()
        {
            _id = gameObject.name;
        }
    }
}

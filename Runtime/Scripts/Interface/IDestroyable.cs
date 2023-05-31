using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public interface IDestroyable<T>
        where T : MonoBehaviour
    {
        event System.Action<T> OnCustomDestroy;
        void CustomDestroy();
    }
}

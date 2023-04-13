using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class Entry : MonoBehaviour
    {
        private EntryData _data;

        private void Start()
        {
            _data = Resources.Load<EntryData>(EntryData.DEFAULT_RESOURCES_PATH);
            Debug.Assert(_data != null);

            AddressableManager.Instance.Initialize();
            CanvasManager.Instance.Initialize();

            UnityEngine.SceneManagement.SceneManager.LoadScene(_data.LoadSceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}

using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class Entry : MonoBehaviour
    {
        private EntryData _data;

        private void Start()
        {
            _data = Resources.Load<EntryData>(EntryData.DefaultResourcesPath);

            GameStateManager.Instance.Initialize();
            AddressableManager.Instance.Initialize();
            LocalizationManager.Instance.Initialize();
            CanvasManager.Instance.Initialize();

            foreach(var assetBundle in _data.LoadAssetBundles)
            {
                AddressableManager.Instance.LoadAssetSync<GameObject>(assetBundle);
            }

            foreach(var assetBundle in _data.InstantiateAssetBundles)
            {
                AddressableManager.Instance.Instantiate<GameObject>(assetBundle);
            }

         
            System.Diagnostics.Debug.Assert(_data != null, nameof(_data) + " != null");
            UnityEngine.SceneManagement.SceneManager.LoadScene(_data.LoadSceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}

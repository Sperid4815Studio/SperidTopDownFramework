using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    [CreateAssetMenu(fileName = "EntryData", menuName = "SperidTopDownFramework/Create Entry")]
    [System.Serializable]
    public class EntryData : ScriptableObject
    {
       
        public const string DefaultResourcesPath = "EntryData";

        [SerializeField] private string _loadSceneName = null;

        [SerializeField] private string[] _loadAssetBundles;

        [SerializeField] private string[] _instantiateAssetBundles;


        public string LoadSceneName => _loadSceneName;

        public string[] LoadAssetBundles => _loadAssetBundles;

        public string[] InstantiateAssetBundles => _instantiateAssetBundles;
    }
}

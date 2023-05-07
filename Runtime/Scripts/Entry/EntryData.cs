using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    [CreateAssetMenu(fileName = "EntryData", menuName = "SperidTopDownFramework/Create Entry")]
    [System.Serializable]
    public class EntryData : ScriptableObject
    {
        [System.Serializable]
        public struct StatePack
        {
            public string Name;
            public GameStateManager.GameState State;
        }

        public const string DefaultResourcesPath = "EntryData";

        [SerializeField] private string _loadSceneName = null;

        [SerializeField] private string[] _loadAssetBundles;

        [SerializeField] private string[] _instantiateAssetBundles;

        [SerializeField] private StatePack[] _registerStatePacks;


        public string LoadSceneName => _loadSceneName;

        public string[] LoadAssetBundles => _loadAssetBundles;

        public string[] InstantiateAssetBundles => _instantiateAssetBundles;

        public StatePack[] RegisterStatePacks => _registerStatePacks;
    }
}

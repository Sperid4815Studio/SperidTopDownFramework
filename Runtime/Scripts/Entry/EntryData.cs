using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    [CreateAssetMenu(fileName = "EntryData", menuName = "SperidTopDownFramework/Create Entry")]
    [System.Serializable]
    public class EntryData : ScriptableObject
    {
        public const string DefaultResourcesPath = "EntryData";

        [SerializeField] private string _loadSceneName = null;


        public string LoadSceneName => _loadSceneName;
    }
}

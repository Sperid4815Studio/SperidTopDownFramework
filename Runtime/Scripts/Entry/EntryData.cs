using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    [CreateAssetMenu(fileName = "EntryData", menuName = "SperidTopDownFramework/Create Entry")]
    [System.Serializable]
    public class EntryData : ScriptableObject
    {
        public const string DEFAULT_RESOURCES_PATH = "EntryData";

        [SerializeField]
        private string _loadSceneName;


        public string LoadSceneName { get => _loadSceneName; }
    }
}

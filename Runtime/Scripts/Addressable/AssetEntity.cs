using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SperidTopDownFramework.Runtime
{
    public class AssetEntity
    {
        public int RefCount { get; set; }
        public AsyncOperationHandle Handle { get; set; }

        public bool IsLoading
        {
            get => Handle.IsDone == false;
        }
    }
}

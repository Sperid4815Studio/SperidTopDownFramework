using UnityEngine.ResourceManagement.AsyncOperations;

namespace SperidTopDownFramework.Runtime
{
    public class AssetEntity
    {
        public int RefCount { get; set; }
        public AsyncOperationHandle Handle { get; set; }

        public bool IsLoading => Handle.IsDone == false;
    }
}

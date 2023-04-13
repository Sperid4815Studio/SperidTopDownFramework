using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class CanvasManager : SingletonBehaviour<CanvasManager>
    {
        public override void Initialize()
        {
            name = "CanvasManager";
            base.Initialize();
        }
    }
}

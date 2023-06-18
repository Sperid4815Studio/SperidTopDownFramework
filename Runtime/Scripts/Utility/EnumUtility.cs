using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public static class EnumUtility
    {
        private static readonly System.Random random = new System.Random();

        public static T GetRandomEnumValue<T>() where T : Enum
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(random.Next(v.Length));
        }
    }
}

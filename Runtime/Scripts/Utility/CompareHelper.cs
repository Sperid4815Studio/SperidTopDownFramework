using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public static class CompareHelper<T> where T : IComparable<T>
    {
        public static bool IsGreaterThanOrEqual(T value1, T value2)
        {
            return value1.CompareTo(value2) >= 0;
        }

        public static bool IsLessThanOrEqual(T value1, T value2)
        {
            return value1.CompareTo(value2) <= 0;
        }

        public static bool IsGreaterEqualAndLessEqual(T value1,T value2, T value3)
        {
            return IsGreaterThanOrEqual(value3, value1) && IsLessThanOrEqual(value3, value2);
        }
    }

}

using UnityEngine;
using System;

namespace KarlsonMod
{
    class Helper
    {
        public static Vector3 StringToVec3(String arg1, String arg2, String arg3)
        {
            return new Vector3(float.Parse(arg1), float.Parse(arg2), float.Parse(arg3));
        }
    }
}

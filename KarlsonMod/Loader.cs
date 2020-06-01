using UnityEngine;
using System;
using System.IO;
using System.Runtime.InteropServices;
namespace KarlsonMod
{
    public class Loader
    {
        [DllImport("Kernel32.dll")]
        private static extern bool FreeConsole();
        public static void Init()
        {
            // console
            ConsoleHelper.Open();
        
            _gameObject = new GameObject("haxer menu");
            _gameObject.AddComponent<Main>();
            GameObject.DontDestroyOnLoad(_gameObject);
        }
        public static void Unload()
        {
            _Unload();
            FreeConsole();
        }
        private static void _Unload()
        {
            GameObject.Destroy(_gameObject);

        }
        private static GameObject _gameObject;
    }
}
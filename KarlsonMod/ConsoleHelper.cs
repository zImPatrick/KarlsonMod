using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEditor;

namespace KarlsonMod
{
    public static class ConsoleHelper
    {
        [DllImport("Kernel32.dll")]
        private static extern bool AllocConsole();

        public static void Open()
        {
            AllocConsole();
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
            Console.WriteLine("KarlsonMod v"+Main.Version);

            Application.logMessageReceivedThreaded += (condition, stackTrace, type) => Console.WriteLine(condition + " " + stackTrace);
        }
    }
}

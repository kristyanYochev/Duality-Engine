using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DualityEngine.Interfaces;

namespace DualityEngine.Implementations
{
    class Console : IConsole
    {
        public bool CursorVisible { get => System.Console.CursorVisible ; set => System.Console.CursorVisible = value; }
        public bool KeyAvailable { get => System.Console.KeyAvailable; }
        public bool TreatControlCAsInput { get => System.Console.TreatControlCAsInput; set => System.Console.TreatControlCAsInput = value; }
        public int WindowWidth { get => System.Console.WindowWidth; set => System.Console.WindowWidth = value; }
        public int WindowHeight { get => System.Console.WindowHeight; set => System.Console.WindowHeight = value; }

        public void Clear()
        {
            System.Console.Clear();
        }

        public Stream OpenStandardOutput()
        {
            return System.Console.OpenStandardOutput();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return System.Console.ReadKey(intercept);
        }

        public void SetIn(TextReader newIn)
        {
            System.Console.SetIn(newIn);
        }
    }
}

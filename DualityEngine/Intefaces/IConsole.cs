using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DualityEngine.Interfaces
{
    public interface IConsole
    {
        bool CursorVisible { get; set; }
        bool KeyAvailable { get; }
        int LargestWindowWidth { get; }
        int LargestWindowHeight { get; }
        bool TreatControlCAsInput { get; set; }
        int WindowWidth { get; set; }
        int WindowHeight { get; set; }
        void Clear();
        Stream OpenStandardOutput();
        Stream OpenStandardOutput(int bufferSize);
        ConsoleKeyInfo ReadKey();
        ConsoleKeyInfo ReadKey(bool intercept);
        void SetIn(TextReader newIn);
    }
}

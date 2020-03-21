﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DualityEngine.Interfaces
{
    public interface IConsole
    {
        bool CursorVisible { get; set; }
        bool KeyAvailable { get; }
        bool TreatControlCAsInput { get; set; }
        int WindowWidth { get; set; }
        int WindowHeight { get; set; }
        void Clear();
        Stream OpenStandardOutput();
        ConsoleKeyInfo ReadKey();
        ConsoleKeyInfo ReadKey(bool intercept);
        void SetIn(TextReader newIn);
    }
}

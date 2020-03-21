using System;
using System.Threading.Tasks;
using System.IO;
using DualityEngine.Interfaces;
using DualityEngine.Implementations;

namespace DualityEngine
{
    public static class Input
    {
        private static IConsole console;
        private static ConsoleKeyInfo KeyPressed { get; set; }
        private static bool IsKeyDown { get; set; } = false;

        public static void Setup(IConsole console)
        {
            Input.console = console;
            Input.console.SetIn(new StreamReader(Stream.Null));
            Input.console.TreatControlCAsInput = true;
        }

        public static void Setup()
        {
            console = new Implementations.Console();
            console.SetIn(new StreamReader(Stream.Null));
            console.TreatControlCAsInput = true;
        }

        public static bool IsKeyPressed(ConsoleKey key)
        {
            return KeyPressed.Key == key && IsKeyDown;
        }

        public static void CollectInput()
        {
            if (console.KeyAvailable)
            {
                KeyPressed = console.ReadKey(true);
                IsKeyDown = true;
            }
            else
            {
                IsKeyDown = false;
            }
        }
    }
}

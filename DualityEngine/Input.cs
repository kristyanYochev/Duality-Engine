using System;
using System.Threading.Tasks;
using System.IO;

namespace DualityEngine
{
    public static class Input
    {
        private static ConsoleKeyInfo KeyPressed { get; set; }
        private static bool IsKeyDown { get; set; } = false;

        public static void Setup()
        {
            Console.SetIn(new StreamReader(Stream.Null));
            Console.TreatControlCAsInput = true;
        }

        public static bool IsKeyPressed(ConsoleKey key)
        {
            return KeyPressed.Key == key && IsKeyDown;
        }

        public static void CollectInput()
        {
            if (Console.KeyAvailable)
            {
                KeyPressed = Console.ReadKey(true);
                IsKeyDown = true;
            }
            else
            {
                IsKeyDown = false;
            }
        }
    }
}

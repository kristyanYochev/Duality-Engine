using System;
using System.Threading.Tasks;
using System.IO;

namespace DualityEngine
{
    public class Input
    {
        private bool InputThreadRunning { get; set; }
        private ConsoleKeyInfo keyPressed;
        private bool isKeyDown = false;

        public Input()
        {
            Console.SetIn(new StreamReader(Stream.Null));
            Console.TreatControlCAsInput = true;

            InputThreadRunning = false;
        }

        ~Input()
        {
            StopInputThread();
        }

        public void StartInputThread()
        {
            if (!InputThreadRunning)
            {
                InputThreadRunning = true;
                Task.Factory.StartNew(() =>
                {
                    while (InputThreadRunning)
                    {
                        CollectInput();
                    }
                });
            }
        }

        public void StopInputThread()
        {
            if (InputThreadRunning)
            {
                InputThreadRunning = false;
            }
        }

        public bool IsKeyPressed(ConsoleKey key)
        {
            return keyPressed.Key == key && isKeyDown;
        }

        private void CollectInput()
        {
            if (Console.KeyAvailable)
            {
                keyPressed = Console.ReadKey(true);
                isKeyDown = true;
            }
            else
            {
                isKeyDown = false;
            }
        }
    }
}

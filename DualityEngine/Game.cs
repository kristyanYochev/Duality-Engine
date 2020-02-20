using System;

namespace DualityEngine
{
    public class Game
    {
        public void Start()
        {
            bool exits = false;

            Input input = new Input();
            input.StartInputThread();

            while (!exits)
            {
                if (input.IsKeyPressed(ConsoleKey.Q))
                {
                    exits = true;
                }
                if (input.IsKeyPressed(ConsoleKey.A))
                {
                    Console.WriteLine("You pressed A");
                }
                Console.WriteLine("Doing shit");
            }

            input.StopInputThread();
        }
    }
}

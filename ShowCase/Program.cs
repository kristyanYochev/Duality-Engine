using System;
using System.Threading;
using DualityEngine;
using DualityEngine.Graphics;


namespace ShowCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Sprite testSprite = Sprite.ParseSprite("/Users/kristyanyochev/Projects/DualityEngine/ShowCase/TestSprite.txt");
            Input input = new Input();
            //input.StartInputThread();

            double posX = 0.5;
            double posY = 0.5;
            const double step = 0.01;

            bool exits = false;

            while (!exits)
            {
                input.CollectInput();
                if (input.IsKeyPressed(ConsoleKey.Q))
                {
                    exits = true;
                }

                if (input.IsKeyPressed(ConsoleKey.W))
                {
                    posY -= step;
                }

                if (input.IsKeyPressed(ConsoleKey.A))
                {
                    posX -= step;
                }

                if (input.IsKeyPressed(ConsoleKey.S))
                {
                    posY += step;
                }

                if (input.IsKeyPressed(ConsoleKey.D))
                {
                    posX += step;
                }

                Rendering.ClearScreen();
                Rendering.RenderSprite(testSprite, posX, posY);
                Thread.Sleep(1000 / 60);
            }

            input.StopInputThread();
        }
    }
}

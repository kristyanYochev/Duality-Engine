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
            Input.Setup();

            double posX = 0.5;
            double posY = 0.5;
            const double step = 0.02;

            bool exits = false;

            while (!exits)
            {
                RateLimiter.LimitRate(60);
                Input.CollectInput();
                if (Input.IsKeyPressed(ConsoleKey.Q))
                {
                    exits = true;
                }

                if (Input.IsKeyPressed(ConsoleKey.W))
                {
                    posY -= step;
                }

                if (Input.IsKeyPressed(ConsoleKey.A))
                {
                    posX -= step;
                }

                if (Input.IsKeyPressed(ConsoleKey.S))
                {
                    posY += step;
                }

                if (Input.IsKeyPressed(ConsoleKey.D))
                {
                    posX += step;
                }

                Rendering.ClearScreen();
                Rendering.RenderSprite(testSprite, posX, posY);
            }
        }
    }
}

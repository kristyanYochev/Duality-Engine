using System;
using System.Threading;
using System.Diagnostics;
using DualityEngine;
using DualityEngine.Components;
using DualityEngine.Graphics;

namespace ShowCase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sprite testSprite = Sprite.ParseSprite("Sprites/TestSprite.txt");
            //Input.Setup();
            //Rendering.Setup();

            //double posX = 0.5;
            //double posY = 0.5;
            //const double step = 0.02;

            //bool exits = false;

            //while (!exits)
            //{
            //    RateLimiter.LimitRate(60);
            //    Input.CollectInput();
            //    if (Input.IsKeyPressed(ConsoleKey.Q))
            //    {
            //        exits = true;
            //    }

            //    if (Input.IsKeyPressed(ConsoleKey.W))
            //    {
            //        posY -= step;
            //    }

            //    if (Input.IsKeyPressed(ConsoleKey.A))
            //    {
            //        posX -= step;
            //    }

            //    if (Input.IsKeyPressed(ConsoleKey.S))
            //    {
            //        posY += step;
            //    }

            //    if (Input.IsKeyPressed(ConsoleKey.D))
            //    {
            //        posX += step;
            //    }

            //    Rendering.ClearScreen();
            //    Rendering.RenderSprite(testSprite, posX, posY);
            //    Rendering.Flip();
            //}
            //Rendering.Teardown();
            Scene mainScene = new Scene();

            GameObject myObject = new GameObject(new DualityEngine.Mathf.Vector2 { x = 0.5f, y = 0.5f }, mainScene);
            myObject.AddComponent(new SpriteRenderer(myObject, Sprite.ParseSprite("Sprites/TestSprite.txt")));
            myObject.AddComponent(new ControllerScript(myObject));

            mainScene.AddObject(myObject);

            mainScene.Run();
        }
    }
}

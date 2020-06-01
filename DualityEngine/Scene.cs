using System;
using System.Collections.Generic;
using DualityEngine.Graphics;

namespace DualityEngine
{
    public class Scene
    {
        public Overlay Overlay { get; private set; }
        public Camera Camera { get; private set; }
        public List<GameObject> GameObjects { get; private set; }
        public bool running = false;
        public bool paused = false;

        public Scene() : this(new Camera())
        { }

        public Scene(Camera camera)
        {
            GameObjects = new List<GameObject>();
            Overlay = new Overlay();
            Camera = camera;
        }

        public void AddObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void RemoveObject(GameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }

        public void Run()
        {
            running = true;
            Input.Setup();
            Rendering.Setup();
            foreach(GameObject gameObject in GameObjects)
            {
                gameObject.Start();
            }

            while (running)
            {
                RateLimiter.LimitRate(60);
                //Console.WriteLine("A frame");
                Rendering.ClearScreen();
                Input.CollectInput();
                while (paused)
                {
                    if (Input.IsKeyPressed(ConsoleKey.Spacebar))
                    {
                        paused = false;
                        break;
                    }
                }
                for (int i = 0; i < GameObjects.Count; i++)
                {
                    GameObject gameObject = GameObjects[i];
                    gameObject.Update();
                }
                Overlay.Render();
                Rendering.Flip();
            }
            Rendering.Teardown();
        }
    }
}

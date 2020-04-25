using System;
using System.Collections.Generic;
using DualityEngine.Graphics;

namespace DualityEngine
{
    public class Scene
    {
        public Overlay Overlay { get; private set; }
        private readonly List<GameObject> gameObjects;
        public bool running = false;

        public Scene()
        {
            gameObjects = new List<GameObject>();
            Overlay = new Overlay();
        }

        public void AddObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void Run()
        {
            running = true;
            Input.Setup();
            Rendering.Setup();
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Start();
            }

            while (running)
            {
                RateLimiter.LimitRate(60);
                Rendering.ClearScreen();
                Input.CollectInput();
                foreach (GameObject gameObject in gameObjects)
                {
                    gameObject.Update();
                }
                Overlay.Render();
                Rendering.Flip();
            }
            Rendering.Teardown();
        }
    }
}

using System;
using System.Collections.Generic;
namespace DualityEngine
{
    public class Scene
    {
        private readonly List<GameObject> gameObjects;

        public Scene()
        {
            gameObjects = new List<GameObject>();
        }

        public void AddObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void Run()
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Start();
            }

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using DualityEngine.Mathf;

namespace DualityEngine
{
    public class GameObject
    {
        private readonly List<Component> components;
        public Vector2Int position;
        public Scene scene;

        public GameObject(Vector2Int position, Scene scene)
        {
            components = new List<Component>();
            this.position = position;
            this.scene = scene;
        }

        public void Start()
        {
            foreach (Component component in components)
            {
                component.Start();
            }
        }

        public void Update()
        {
            foreach (Component component in components)
            {
                component.Update();
            }
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

        public Component GetComponent<T>()
        {
            return components.Find(c => c is T);
        }
    }
}

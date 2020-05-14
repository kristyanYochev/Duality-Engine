using System;
using System.Linq;
using System.Collections.Generic;
using DualityEngine.Mathf;

namespace DualityEngine
{
    public class GameObject
    {
        public List<Component> components { get; private set; }
        public Vector2Int position;
        public Scene scene;
        public string Tag { get; private set; }

        public GameObject(Vector2Int position, Scene scene, string tag)
        {
            components = new List<Component>();
            this.position = position;
            this.scene = scene;
            Tag = tag;
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

        public List<T> GetComponent<T>() where T : Component
        {
            return components.OfType<T>().ToList();
        }
    }
}

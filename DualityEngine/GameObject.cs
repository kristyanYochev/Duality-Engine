using System;
using System.Collections.Generic;

namespace DualityEngine
{
    public class GameObject : IComponent
    {
        private readonly List<IComponent> components;

        public GameObject()
        {
            components = new List<IComponent>();
        }

        public void Start()
        {
            foreach (IComponent component in components)
            {
                component.Start();
            }
        }

        public void Update()
        {
            foreach (IComponent component in components)
            {
                component.Update();
            }
        }

        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public IComponent GetComponent<T>()
        {
            return components.Find(c => c is T);
        }
    }
}

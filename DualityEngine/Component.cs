using System;
namespace DualityEngine
{
    public abstract class Component
    {
        protected GameObject gameObject;

        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public abstract void Start();
        public abstract void Update();
        public virtual void OnCollisionEnter(GameObject other) { }
    }
}

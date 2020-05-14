using System;
using System.Linq;
using System.Collections.Generic;
using DualityEngine.Mathf;

namespace DualityEngine.Components
{
    public class BoxCollider : Component
    {
        private Vector2Int BasePos { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Static { get; private set; }

        public Vector2Int Position
        {
            get
            {
                return gameObject.position + BasePos;
            }
        }

        public BoxCollider(GameObject gameObject, Vector2Int basePos, int width, int height, bool @static) : base(gameObject)
        {
            BasePos = basePos;
            Width = width;
            Height = height;
            Static = @static;
        }

        public override void Start()
        {
        }

        public override void Update()
        {
            for (int i = 0; i < gameObject.scene.GameObjects.Count; i++)
            {
                GameObject otherGameObject = gameObject.scene.GameObjects[i];
                List<BoxCollider> otherCollider = otherGameObject.GetComponent<BoxCollider>();
                if (otherCollider.Count == 0) continue;

                foreach (BoxCollider collider in otherCollider)
                {
                    if (Static && collider.Static)
                    {
                        continue;
                    }
                    if (HasCollision(collider))
                    {
                        foreach(Component component in gameObject.components)
                        {
                            component.OnCollisionEnter(otherGameObject);
                        }

                        foreach(Component component in otherGameObject.components)
                        {
                            component.OnCollisionEnter(gameObject);
                        }

                        break;
                    }
                }
            }
        }

        private bool HasCollision(BoxCollider other)
        {
            if (Position.X >= other.Position.X + other.Width || other.Position.X >= Position.X + Width) return false;

            if (Position.Y >= other.Position.Y + other.Height || other.Position.Y >= Position.Y + Height) return false;

            return true;
        }
    }
}

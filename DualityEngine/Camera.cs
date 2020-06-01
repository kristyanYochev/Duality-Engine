using System;
using DualityEngine.Mathf;
using DualityEngine.Graphics;

namespace DualityEngine
{
    public class Camera
    {
        public Vector2Int Position { get; set; }

        public Camera()
        {
            Position = new Vector2Int(0, 0);
        }

        public Camera(Vector2Int position)
        {
            Position = position;
        }

        public void RenderSprite(Sprite sprite, Vector2Int globalPosition)
        {
            Rendering.RenderSprite(sprite, globalPosition - Position);
        }
    }
}

using System;
using DualityEngine.Graphics;
namespace DualityEngine.Components
{
    public class SpriteRenderer : Component
    {
        private Sprite sprite;

        public SpriteRenderer(GameObject gameObject, Sprite sprite) : base(gameObject)
        {
            this.sprite = sprite;
        }

        public override void Start() { }

        public override void Update()
        {
            Rendering.RenderSprite(sprite, gameObject.position.x, gameObject.position.y);
        }
    }
}

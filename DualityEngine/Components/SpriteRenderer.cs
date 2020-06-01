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
            gameObject.scene.Camera.RenderSprite(sprite, gameObject.position);
        }
    }
}

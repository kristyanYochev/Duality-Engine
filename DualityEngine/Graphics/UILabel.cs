using DualityEngine.Mathf;
using System;
using System.Collections.Generic;
using System.Text;

namespace DualityEngine.Graphics
{
    public class UILabel : UIElement
    {
        public string Content { get; set; }
        public Vector2 Position { get; set; }

        public UILabel(string content, Vector2 position)
        {
            this.Content = content;
            this.Position = position;
        }

        public UILabel(Vector2 position) : this("", position)
        {
        }

        public void Render()
        {
            Sprite sprite = new Sprite(Content, 1, Content.Length);
            Rendering.RenderSprite(sprite, Position.x, Position.y);
        }
    }
}

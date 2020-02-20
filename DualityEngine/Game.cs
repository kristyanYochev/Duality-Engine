using System;

namespace DualityEngine
{   
    public class Game
    {
        public void Start()
        {
            Sprite sprite = new Sprite("+--+|  |+--+", 3, 4);
            Rendering.RenderSprite(sprite, -0.01, -0.05);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DualityEngine;
using DualityEngine.Graphics;

namespace DualityEngine.Components
{
    public class AnimationController : Component
    {
        private long LastCallMillis = 0;
        private int currentFrame = 0;
        private Animation animation;
        public AnimationController(GameObject gameObject, Animation animation) : base(gameObject)
        {
            this.animation = animation;
        }

        public override void Start()
        {
            LastCallMillis = RateLimiter.CurrMillis;
        }

        public override void Update()
        {
            if (RateLimiter.CurrMillis - LastCallMillis > 1000 / animation.FrameRate)
            {
                currentFrame = (currentFrame + 1) % animation.FrameCount;
                LastCallMillis = RateLimiter.CurrMillis;
            }

            Rendering.RenderSprite(animation.Sprites[currentFrame], gameObject.position.x, gameObject.position.y);
            
        }
    }
}

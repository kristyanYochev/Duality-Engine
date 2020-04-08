using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace DualityEngine.Graphics
{
    class JAnimation 
    {
        public double FrameRate { get; set; }
        public string[] FramePaths { get; set; }
    }
    public class Animation
    {
        public Sprite[] Sprites { get; private set; }
        public double FrameRate { get; private set; }
        public int FrameCount { 
            get {
                return Sprites.Length;
            } 
        }

        public Animation(Sprite[] sprites, double frameRate)
        {
            this.Sprites = sprites;
            this.FrameRate = frameRate;
        }

        public static Animation ParseAnimation(string path)
        {
            string json = File.ReadAllText(path);
            JAnimation jAnimation = JsonConvert.DeserializeObject<JAnimation>(json);
            Sprite[] sprites = new Sprite[jAnimation.FramePaths.Length];
            
            for(int i = 0; i < sprites.Length; ++i)
            {
                sprites[i] = Sprite.ParseSprite(jAnimation.FramePaths[i]);
            }

            return new Animation(sprites, jAnimation.FrameRate);
        }



    }
}

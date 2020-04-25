using System;
using System.Threading;
using System.Diagnostics;
using DualityEngine;
using DualityEngine.Components;
using DualityEngine.Graphics;
using ShowCase.Scripts;

namespace ShowCase
{
    class Program
    {
        static void Main(string[] args)
        {
            DualityEngine.Debug.Instance.SetUp("Logs.log");
            Scene mainScene = new Scene();
            mainScene.Overlay.AddElement("Jump count", new UILabel("Jumps: 0", new DualityEngine.Mathf.Vector2 {x = 0.1f, y = 0.1f}));
            //GameObject stick = new GameObject(new DualityEngine.Mathf.Vector2 { x = 0.5f, y = 0.5f }, mainScene);
            //stick.AddComponent(new AnimationController(stick, Animation.ParseAnimation("Sprites/Animes.json")));
            //mainScene.AddObject(stick);
            GameObject dinosaur = new GameObject(new DualityEngine.Mathf.Vector2 { x = 0.5f, y = 0.7f }, mainScene);
            dinosaur.AddComponent(new SpriteRenderer(dinosaur, Sprite.ParseSprite("Sprites/Dino.txt")));
            dinosaur.AddComponent(new DinoController(dinosaur));

            mainScene.AddObject(dinosaur);

            mainScene.Run();
            DualityEngine.Debug.Instance.TearDown();
        }
    }
}

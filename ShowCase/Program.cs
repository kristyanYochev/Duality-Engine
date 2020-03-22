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
            Scene mainScene = new Scene();

            GameObject dinosaur = new GameObject(new DualityEngine.Mathf.Vector2 { x = 0.5f, y = 0.7f }, mainScene);
            dinosaur.AddComponent(new SpriteRenderer(dinosaur, Sprite.ParseSprite("Sprites/Dino.txt")));
            dinosaur.AddComponent(new DinoController(dinosaur));

            mainScene.AddObject(dinosaur);

            mainScene.Run();
        }
    }
}

using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using DualityEngine;
using DualityEngine.Components;
using DualityEngine.Graphics;
using DualityEngine.Mathf;

namespace ShowCase
{
    class Program
    {
        static void Main(string[] args)
        {
            DualityEngine.Debug.Instance.SetUp("Logs.log");

            Scene scene = new Scene();

            string[] mapFile = File.ReadAllLines("Sprites/map.txt");

            for (int line = 0; line < mapFile.Length; line++)
            {
                for (int symbol = 0; symbol < mapFile[line].Length; symbol++)
                {
                    switch (mapFile[line][symbol])
                    {
                        case '#':
                            GameObject wall = new GameObject(new Vector2Int(symbol, line), scene);
                            wall.AddComponent(new SpriteRenderer(wall, new Sprite("#", 1, 1)));
                            scene.AddObject(wall);
                            break;
                        case '.':
                            GameObject dot = new GameObject(new Vector2Int(symbol, line), scene);
                            dot.AddComponent(new SpriteRenderer(dot, new Sprite(".", 1, 1)));
                            scene.AddObject(dot);
                            break;
                        default:
                            break;
                    }
                }
            }

            scene.Run();

            DualityEngine.Debug.Instance.TearDown();
        }
    }
}

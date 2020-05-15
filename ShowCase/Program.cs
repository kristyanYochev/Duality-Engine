using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using DualityEngine;
using DualityEngine.Components;
using DualityEngine.Graphics;
using DualityEngine.Mathf;
using ShowCase.Scripts;

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
                            GameObject wall = new GameObject(new Vector2Int(symbol, line), scene, "Wall");
                            wall.AddComponent(new SpriteRenderer(wall, new Sprite("#", 1, 1)));
                            wall.AddComponent(new BoxCollider(wall, new Vector2Int(0, 0), 1, 1, true));
                            scene.AddObject(wall);
                            break;
                        case '.':
                            GameObject dot = new GameObject(new Vector2Int(symbol, line), scene, "Dot");
                            dot.AddComponent(new SpriteRenderer(dot, new Sprite(".", 1, 1)));
                            dot.AddComponent(new BoxCollider(dot, new Vector2Int(0, 0), 1, 1, true));
                            dot.AddComponent(new DotController(dot));
                            scene.AddObject(dot);
                            break;
                        default:
                            break;
                    }
                }
            }

            GameObject pacman = new GameObject(new Vector2Int(19, 13), scene, "Pacman");

            pacman.AddComponent(new SpriteRenderer(pacman, new Sprite("0", 1, 1)));
            pacman.AddComponent(new BoxCollider(pacman, new Vector2Int(0, 0), 1, 1, false));
            pacman.AddComponent(new PacmanController(pacman));
            scene.AddObject(pacman);

            GameObject ghost = new GameObject(new Vector2Int(1, 1), scene, "Ghost");
            ghost.AddComponent(new SpriteRenderer(ghost, new Sprite("M", 1, 1)));
            ghost.AddComponent(new BasicGhostController(ghost, pacman));
            scene.AddObject(ghost);

            scene.Run();

            DualityEngine.Debug.Instance.TearDown();
        }
    }
}

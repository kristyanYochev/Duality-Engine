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
            scene.Overlay.AddElement("ScoreCounter", new UILabel("Score: 0", new Vector2Int(50, 0)));
            scene.Overlay.AddElement("Win/Lose Message", new UILabel("", new Vector2Int(50, 10)));

            string[] mapFile = File.ReadAllLines("Sprites/map.txt");

            int numberOfDots = 0;

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
                            numberOfDots++;
                            break;
                        default:
                            break;
                    }
                }
            }

            GameObject managerObject = new GameObject(new Vector2Int(0, 0), scene, "");
            GameManager manager = new GameManager(managerObject, numberOfDots);
            managerObject.AddComponent(manager);
            scene.AddObject(managerObject);

            GameObject pacman = new GameObject(new Vector2Int(18, 13), scene, "Pacman");

            pacman.AddComponent(new SpriteRenderer(pacman, new Sprite("0", 1, 1)));
            pacman.AddComponent(new BoxCollider(pacman, new Vector2Int(0, 0), 1, 1, false));
            pacman.AddComponent(new PacmanController(pacman, manager));
            scene.AddObject(pacman);

            GameObject blinky = new GameObject(new Vector2Int(1, 1), scene, "Ghost");
            blinky.AddComponent(new SpriteRenderer(blinky, new Sprite("M", 1, 1)));
            blinky.AddComponent(new BoxCollider(blinky, new Vector2Int(0, 0), 1, 1, false));
            blinky.AddComponent(new RedGhostController(blinky, pacman));
            scene.AddObject(blinky);

            GameObject inky = new GameObject(new Vector2Int(26, 1), scene, "Ghost");
            inky.AddComponent(new SpriteRenderer(inky, new Sprite("W", 1, 1)));
            inky.AddComponent(new BoxCollider(inky, new Vector2Int(0, 0), 1, 1, false));
            inky.AddComponent(new BlueGhostController(inky, pacman, blinky));
            scene.AddObject(inky);

            scene.Run();

            DualityEngine.Debug.Instance.TearDown();
        }
    }
}

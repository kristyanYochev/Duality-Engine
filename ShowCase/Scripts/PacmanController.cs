using System;
using DualityEngine;
using DualityEngine.Mathf;

namespace ShowCase.Scripts
{
    public class PacmanController : Component
    {
        readonly Vector2Int LEFT = new Vector2Int(-1, 0);
        readonly Vector2Int RIGHT = new Vector2Int(1, 0);
        readonly Vector2Int UP = new Vector2Int(0, -1);
        readonly Vector2Int DOWN = new Vector2Int(0, 1);
        GameManager manager;
        public string direction; 

        private Vector2Int velocity = new Vector2Int(0, 0);

        public PacmanController(GameObject gameObject, GameManager manager) : base(gameObject)
        {
            this.manager = manager;
        }

        public override void Start()
        {
        }

        public override void Update()
        {
            if (Input.IsKeyPressed(ConsoleKey.W))
            {
                velocity = UP;
                direction = "Up";
            }

            if (Input.IsKeyPressed(ConsoleKey.A))
            {
                velocity = LEFT;
                direction = "Left";
            }

            if (Input.IsKeyPressed(ConsoleKey.S))
            {
                velocity = DOWN;
                direction = "Down";
            }

            if (Input.IsKeyPressed(ConsoleKey.D))
            {
                velocity = RIGHT;
                direction = "Right";
            }

            gameObject.position += velocity;
        }

        public override void OnCollisionEnter(GameObject other)
        {
            if (other.Tag == "Wall")
            {
                gameObject.position += velocity * -1;
                velocity = new Vector2Int(0, 0);
            }
            else if (other.Tag == "Ghost")
            {
                manager.LoseGame();
            }
            else if (other.Tag == "Dot")
            {
                manager.EatDot();
            }
        }
    }
}

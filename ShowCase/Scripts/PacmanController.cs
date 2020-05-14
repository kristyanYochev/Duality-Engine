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

        private Vector2Int velocity = new Vector2Int(0, 0);

        public PacmanController(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Start()
        {
        }

        public override void Update()
        {
            if (Input.IsKeyPressed(ConsoleKey.W))
            {
                velocity = UP;
            }

            if (Input.IsKeyPressed(ConsoleKey.A))
            {
                velocity = LEFT;
            }

            if (Input.IsKeyPressed(ConsoleKey.S))
            {
                velocity = DOWN;
            }

            if (Input.IsKeyPressed(ConsoleKey.D))
            {
                velocity = RIGHT;
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
        }
    }
}

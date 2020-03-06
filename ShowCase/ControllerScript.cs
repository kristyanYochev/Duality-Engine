using System;
using DualityEngine;

namespace ShowCase
{
    public class ControllerScript : Component
    {
        readonly float speed = 0.01f;
        public ControllerScript(GameObject gameObject) : base(gameObject) { }

        public override void Start() { }

        public override void Update()
        {
            if (Input.IsKeyPressed(ConsoleKey.W))
            {
                gameObject.position.y -= speed;
            }

            if (Input.IsKeyPressed(ConsoleKey.A))
            {
                gameObject.position.x -= speed;
            }

            if (Input.IsKeyPressed(ConsoleKey.S))
            {
                gameObject.position.y += speed;
            }

            if (Input.IsKeyPressed(ConsoleKey.D))
            {
                gameObject.position.x += speed;
            }

            if (Input.IsKeyPressed(ConsoleKey.Q))
            {
                gameObject.scene.running = false;
            }
        }
    }
}

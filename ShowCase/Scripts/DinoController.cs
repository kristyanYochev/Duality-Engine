using System;
using DualityEngine;
using DualityEngine.Mathf;

namespace ShowCase.Scripts
{
    public class DinoController : Component
    {
        private readonly float jumpForce = 0.08f;
        private readonly float horizontalSpeed = 0.05f;
        private readonly float gravity = 0.01f;
        private readonly Vector2 initialPosition;
        private float upVelocity = 0;

        public DinoController(GameObject gameObject) : base(gameObject)
        {
            initialPosition = gameObject.position;
        }

        public override void Start()
        {
            Debug.Instance.Log("Start of dino script");
        }

        public override void Update()
        {
            if (Input.IsKeyPressed(ConsoleKey.A))
            {
                gameObject.position.x -= horizontalSpeed;
            }

            if (Input.IsKeyPressed(ConsoleKey.D))
            {
                gameObject.position.x += horizontalSpeed;
                Debug.Instance.Log("Right key pressed");
            }

            if (Input.IsKeyPressed(ConsoleKey.Q))
            {
                gameObject.scene.running = false;
            }

            if (Input.IsKeyPressed(ConsoleKey.Spacebar) && gameObject.position.y >= initialPosition.y)
            {
                upVelocity = jumpForce;
            }

            gameObject.position.y -= upVelocity;
            upVelocity -= gravity;

            if (gameObject.position.y >= initialPosition.y)
            {
                upVelocity = 0;
                gameObject.position.y = initialPosition.y;
            }
        }
    }
}

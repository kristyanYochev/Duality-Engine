using System;
using System.Linq;
using System.Collections.Generic;
using DualityEngine;
using DualityEngine.Mathf;

namespace ShowCase.Scripts
{
    class BlueGhostController : Component
    {
        readonly Vector2Int LEFT = new Vector2Int(-1, 0);
        readonly Vector2Int RIGHT = new Vector2Int(1, 0);
        readonly Vector2Int UP = new Vector2Int(0, -1);
        readonly Vector2Int DOWN = new Vector2Int(0, 1);

        GameObject pacman;
        GameObject blinky;
        int frameskip = 2; // skipping frames to reduce speed of ghost
        int currFrame = 0;

        public  BlueGhostController(GameObject gameObject, GameObject pacman, GameObject blinky) : base(gameObject)
        {
            this.pacman = pacman;
            this.blinky = blinky;
        }

        private Vector2Int determineTarget(PacmanController Pacman)
        {
            Vector2Int targetPacman = pacman.position;
            Vector2Int targetlBlinky = blinky.position;
            if (Pacman.direction == "Right")
            {
                targetPacman.X += 2;
            }

            else if (Pacman.direction == "Left")
            {
                targetPacman.X -= 2;
            }

            else if (Pacman.direction == "Down")
            {
                targetPacman.Y += 2;
            }

            else if (Pacman.direction == "Up")
            {
                targetPacman.Y -= 2;
                targetPacman.X -= 2;
            }
            return new Vector2Int(targetPacman.X - targetlBlinky.X, targetPacman.Y - targetlBlinky.Y);
        }
        public override void Start()
        { }

        public override void Update()
        {
            currFrame++;
            currFrame = currFrame % frameskip;
            if (currFrame != 0) return;
            

            // TODO: Implement "No going back" policy

            // Get walls game objects around the ghost
            List<Vector2Int> wallPositions = gameObject.scene.GameObjects
                .Where((GameObject arg) => Vector2Int.Distance(arg.position, gameObject.position) <= 1 && arg.Tag == "Wall")
                .Select((GameObject arg) => arg.position)
                .ToList();

            List<Vector2Int> pointsToCheck = new List<Vector2Int>() {
                LEFT + gameObject.position,
                RIGHT + gameObject.position,
                UP + gameObject.position,
                DOWN + gameObject.position };
            foreach (Vector2Int wallPosition in wallPositions)
            {
                pointsToCheck.Remove(wallPosition);
            }

            if (pointsToCheck.Count == 0) return;

            Vector2Int closestToTarget = new Vector2Int(0, 0);
            Vector2Int target = determineTarget(pacman.GetComponent<PacmanController>().First());
            float closestDistance = float.MaxValue;

            for (int i = 0; i < pointsToCheck.Count; i++)
            {
                if (Vector2Int.Distance(pointsToCheck[i], target) < closestDistance)
                {
                    closestDistance = Vector2Int.Distance(pointsToCheck[i], target);
                    closestToTarget = pointsToCheck[i];
                }
            }

            gameObject.position = closestToTarget;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using DualityEngine;
using DualityEngine.Mathf;

namespace ShowCase.Scripts
{
    public class RedGhostController : Component
    {
        readonly Vector2Int LEFT = new Vector2Int(-1, 0);
        readonly Vector2Int RIGHT = new Vector2Int(1, 0);
        readonly Vector2Int UP = new Vector2Int(0, -1);
        readonly Vector2Int DOWN = new Vector2Int(0, 1);

        GameObject pacman;
        int frameskip = 2; // skipping frames to reduce speed of ghost
        int currFrame = 0;

        public RedGhostController(GameObject gameObject, GameObject pacman) : base(gameObject)
        {
            this.pacman = pacman;
        }

        public override void Start()
        { }

        public override void Update()
        {
            currFrame++;
            currFrame = currFrame % frameskip;
            if (currFrame != 0) return;

            Vector2Int target = pacman.position;

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
            foreach(Vector2Int wallPosition in wallPositions)
            {
                pointsToCheck.Remove(wallPosition);
            }

            if (pointsToCheck.Count == 0) return;

            Vector2Int closestToTarget = new Vector2Int(0, 0);
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

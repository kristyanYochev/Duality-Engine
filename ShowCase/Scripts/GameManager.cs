using System;
using DualityEngine;

namespace ShowCase.Scripts
{
    public class GameManager : Component
    {
        private int score = 0;
        private int maxScore;

        public GameManager(GameObject gameObject, int maxScore) : base(gameObject)
        {
            this.maxScore = maxScore;
        }

        public override void Start()
        {
        }

        public override void Update()
        {
        }

        public void LoseGame()
        {
            gameObject.scene.Overlay.GetElement("Win/Lose Message").Content = "You Lose";
        }

        public void EatDot()
        {
            score++;

            if (score >= maxScore)
            {
                WinGame();
            }

            gameObject.scene.Overlay.GetElement("ScoreCounter").Content = $"Score: {score}";
        }

        private void WinGame()
        {
            gameObject.scene.Overlay.GetElement("Win/Lose Message").Content = "You Win!!!!";
        }
    }
}

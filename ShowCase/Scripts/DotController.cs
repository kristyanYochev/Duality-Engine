using System;
using System.Diagnostics;
using DualityEngine;

namespace ShowCase.Scripts
{
    public class DotController : Component
    {
        public DotController(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Start()
        {
        }

        public override void Update()
        {
        }

        public override void OnCollisionEnter(GameObject other)
        {
            gameObject.scene.RemoveObject(gameObject);
        }
    }
}

using System;
using System.Threading;
using System.Diagnostics;
using DualityEngine;
using DualityEngine.Components;
using DualityEngine.Graphics;
using ShowCase.Scripts;

namespace ShowCase
{
    class Program
    {
        static void Main(string[] args)
        {
            DualityEngine.Debug.Instance.SetUp("Logs.log");
            DualityEngine.Debug.Instance.TearDown();
        }
    }
}

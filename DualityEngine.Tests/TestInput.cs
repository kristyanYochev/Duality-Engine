using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DualityEngine.Interfaces;
using DualityEngine;
using Moq;
namespace DualityEngineTests
{
    [TestFixture]
    class TestInput
    {
        Mock<IConsole> mockConsole;
        [SetUp]
        public void SetUp()
        {
            mockConsole = new Mock<IConsole>();
        }

        [Test]
        public void TestIsKeyPressed()
        {
            mockConsole.Setup(mock => mock.KeyAvailable).Returns(true);
            mockConsole.Setup(mock => mock.ReadKey(true)).Returns(new ConsoleKeyInfo('u', ConsoleKey.U, false, false, false));
            Input.Setup(mockConsole.Object);
            Input.CollectInput();
            Assert.IsTrue(Input.IsKeyPressed(ConsoleKey.U));
        }

        [Test]
        public void TestKeyIsNotPressed()
        {
            mockConsole.Setup(mock => mock.KeyAvailable).Returns(false);
            mockConsole.Setup(mock => mock.ReadKey(true)).Returns(new ConsoleKeyInfo('u', ConsoleKey.U, false, false, false));
            Input.Setup(mockConsole.Object);
            Input.CollectInput();
            Assert.IsFalse(Input.IsKeyPressed(ConsoleKey.U));
        }
        
        [Test]
        public void TestDifferentKeyIsPressed()
        {
            mockConsole.Setup(mock => mock.KeyAvailable).Returns(true);
            mockConsole.Setup(mock => mock.ReadKey(true)).Returns(new ConsoleKeyInfo('u', ConsoleKey.U, false, false, false));
            Input.Setup(mockConsole.Object);
            Input.CollectInput();
            Assert.IsFalse(Input.IsKeyPressed(ConsoleKey.K));
        }
    }
}

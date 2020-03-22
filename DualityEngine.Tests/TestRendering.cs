using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using DualityEngine.Graphics;
using DualityEngine.Interfaces;
using Moq;
using NUnit.Framework;
namespace DualityEngineTests
{
    [TestFixture]
    class TestRendering
    {
        Mock<IConsole> mockConsole;
        Stream testStream;
        [SetUp]
        public void SetUp()
        {
            mockConsole = new Mock<IConsole>();
            testStream = new MemoryStream();
            mockConsole.Setup(mock => mock.LargestWindowHeight).Returns(5);
            mockConsole.Setup(mock => mock.LargestWindowWidth).Returns(5);
            mockConsole.Setup(mock => mock.WindowHeight).Returns(5);
            mockConsole.Setup(mock => mock.WindowWidth).Returns(5);
            mockConsole.Setup(mock => mock.OpenStandardOutput(25)).Returns(testStream);
        }

        [Test]
        public void TestSpriteRender_1()
        {
            Rendering.Setup(mockConsole.Object);
            Sprite testSprite = new Sprite("*", 1, 1);
            Rendering.ClearScreen();
            Rendering.RenderSprite(testSprite, 0, 0);
            Rendering.Flip();
            testStream.Flush();
            string renderOut;

            using (StreamReader sr = new StreamReader(testStream, Encoding.ASCII))
            {
                sr.DiscardBufferedData();
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                renderOut = sr.ReadToEnd();
            } 

            Rendering.Teardown();
            Assert.AreEqual('*', renderOut[0]);
            Assert.AreEqual(5, renderOut.Split('\n').Length);
        }

        [Test]
        public void TestClearScreen()
        {
            Rendering.Setup(mockConsole.Object);
            Rendering.ClearScreen();
            Rendering.Flip();
            testStream.Flush();
            string renderOut;

            using (StreamReader sr = new StreamReader(testStream, Encoding.ASCII))
            {
                sr.DiscardBufferedData();
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                renderOut = sr.ReadToEnd();
            }

            Rendering.Teardown();
            Assert.AreEqual(5, renderOut.Split('\n').Length);
        }
    }
}

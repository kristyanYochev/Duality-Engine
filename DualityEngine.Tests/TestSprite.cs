using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DualityEngine.Graphics;
using DualityEngine.Exceptions;

namespace DualityEngineTests
{
    [TestFixture]
    public class TestSprite
    {
        Sprite testSprite;

        [SetUp]
        public void SetUp()
        {
            testSprite = new Sprite("*",1,1);
        }

        [Test]
        public void TestGetCharAt()
        {
            Assert.AreEqual('*', testSprite.GetCharAt(0, 0));
        }

        [Test]
        public void TestInvalidGetCharAt()
        {
            Assert.Throws<CoordinatesOutOfBoundsException>(()=>testSprite.GetCharAt(10, 10));
        }
    }
}

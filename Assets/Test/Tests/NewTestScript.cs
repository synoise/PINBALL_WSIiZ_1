using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace theGame
{
    public class AssetsTests
    {

        public Pacman testingObj;
        [Test]
        public void AssetsTestsSimplePasses()
        {
            testingObj = new Pacman();
            Assert.IsNull(testingObj);
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [Test]
        public void AssetsTestsWithEnumeratorPasses()
        {
            testingObj = new Pacman();
            var x = testingObj.calculate(2, 2);
            Assert.AreEqual(4,x);

        }
        
        [Test]
        public void AssetsTestsWithArrayPasses()
        {
            testingObj = new Pacman();
            var x = testingObj.makeArrayRandom(4);
            Assert.IsInstanceOf<Array>(x);

        }
        
        [Test]
        public void AssetsTestsWithArrayLengthPasses()
        {
            testingObj = new Pacman();
            var x = testingObj.makeArrayRandom(5);
            Assert.LessOrEqual(x.Length,6);

        }
        
    }
}

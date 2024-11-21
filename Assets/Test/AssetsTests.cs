// using System.Collections;
// using NUnit.Framework;
//
// using System;using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.Assertions;
// using UnityEngine.TestTools;
//
// namespace theGame
// {
//     public class AssetsTests
//     {
//
//         public Pacman testingObj;
//         [Test]
//         public void AssetsTestsSimplePasses()
//         {
//             testingObj = new Pacman();
//             Assert.IsNull(testingObj);
//         }
//
//         // A UnityTest behaves like a coroutine in PlayMode
//         // and allows you to yield null to skip a frame in EditMode
//         [Test]
//         public void AssetsTestsWithEnumeratorPasses()
//         {
//             testingObj = new Pacman();
//              var x = testingObj.calculate(2, 2);
//             Assert.AreEqual(4,x);
//
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using Fungus;

namespace Tests
{
    public class TestGlobalsScript : MonoBehaviour
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDoorOne() {
            Assert.IsTrue(Globals.getDoor(1));
        }

        [Test]
        public void TestSceneStrings() {
            Assert.AreEqual("L1_P1", Globals.getPuzzleSceneString(1));
            Assert.AreEqual("L1_P2", Globals.getPuzzleSceneString(2));
            Assert.AreEqual("L1_P3", Globals.getPuzzleSceneString(3));
        }

        [Test]
        public void TestOpenDoors() {
            Globals.setDoor(2, true);
            Globals.setDoor(3, true);
            Assert.IsTrue(Globals.getDoor(1));
            Assert.IsTrue(Globals.getDoor(2));
            Assert.IsTrue(Globals.getDoor(3));
        }


        [TearDown]
        public void Teardown()
        {
            
        }
   }
}

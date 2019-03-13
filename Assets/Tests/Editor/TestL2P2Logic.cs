using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using Fungus;

namespace Tests {
    public class TestL2P2Logic : MonoBehaviour
    {   

        GameObject go;
        L2P2Logic logic;

        [SetUp]
        public void Setup()
        {
            go = new GameObject();
            logic = go.AddComponent<L2P2Logic>();
            logic.Start(); 
        }

        [Test]
        public void TestAddPlacedCrayon() {
            logic.AddPlacedCrayon((new GameObject()).GetInstanceID());
            Assert.IsFalse(logic.IsLevelComplete());
        }

        [Test]
        public void TestAddRemovePlacedCrayon() {
            int instanceId = (new GameObject()).GetInstanceID();
            logic.AddPlacedCrayon(instanceId);
            logic.RemovePlacedCrayon(instanceId);
            Assert.IsFalse(logic.IsLevelComplete());
        }

        [Test]
        public void TestAddCorrectCrayon() {
            logic.AddCorrectCrayon((new GameObject()).GetInstanceID());
            Assert.IsFalse(logic.IsLevelComplete());
        }

        [Test]
        public void TestAddRemoveCorrectCrayon() {
            int instanceId = (new GameObject()).GetInstanceID();
            logic.AddCorrectCrayon(instanceId);
            logic.RemoveCorrectCrayon(instanceId);
            Assert.IsFalse(logic.IsLevelComplete());
        }

        [Test]
        public void TestAddFiveCorrect() {
            for (int i = 0; i < 5; i++) {
                int instanceId = (new GameObject()).GetInstanceID();
                logic.AddCorrectCrayon(instanceId);
            }
            Assert.IsTrue(logic.IsLevelComplete());
        }


        [Test]
        public void TestAddRemoveFiveIncorrect() {
            int[] gameObjectHashes = new int[5];  
            for (int i = 0; i < 5; i++) {
                int instanceId = (new GameObject()).GetInstanceID();
                gameObjectHashes[i] = instanceId;
                logic.AddCorrectCrayon(instanceId);
            }

            for (int i = 0; i < 5; i++) {
                int instanceId = gameObjectHashes[i];
                logic.RemoveCorrectCrayon(instanceId);
            }
            Assert.IsFalse(logic.IsLevelComplete());
        }

        [TearDown]
        public void Teardown()
        {
            
        }
    }
}


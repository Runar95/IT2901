using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class TestInteractiveIndicator
    {
        //an object to test with
        private GameObject cube;
        //the original sclae of the given object
        private Vector3 originalScale;
        InteractableIndicator ii;

        [SetUp]
        public void SetUpTest()
        {
            //creates a cube to use in test
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<global::InteractableIndicator>();

            //save original scale of object as a variable
            originalScale = cube.transform.localScale;

            //set InteractableIndicator as public variable for easy access
            ii = cube.GetComponent<InteractableIndicator>();
            ii.Start();
        }

        [Test]
        public void TestIfScalesOnHover()
        {
            //just checks to see if scale is somehow initialized to 0 or null
            Assert.AreNotEqual(originalScale, new Vector3(0.0f, 0.0f, 0.0f));
            Assert.AreNotEqual(originalScale, null);

            //checks to see if scales increase as they should on hover
            ii.OnMouseEnter();
            Assert.AreNotEqual(originalScale, cube.transform.localScale);

            //checks if scale returns to normal after removing the cursor
            ii.OnMouseExit();
            Assert.AreEqual(originalScale, cube.transform.localScale);
        }


    }

}
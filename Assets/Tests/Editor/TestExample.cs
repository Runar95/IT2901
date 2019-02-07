using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Fungus;


namespace Tests
{
    public class TestExample
    {
        
        [Test]
        public void TestAssertions()
        {
            Assert.AreEqual(true, true);
            Assert.AreEqual(false, !true);
        }

    }
}

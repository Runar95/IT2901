using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Fungus;

namespace Tests
{
    
    public class PlayTestExample
    {

        [UnityTest]
        public IEnumerator TestSimultaneusly()
        {
            yield return null;
        } 

    }
}

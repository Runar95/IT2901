using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Fungus;


namespace Tests
{
    public class TetDialogController
    {
        private Flowchart f;
        

        //functions create a flowchart with two blocks
        [SetUp]
        public void CreateFlowchart()
        {
            //creates a flowchart for use in the test
            GameObject go = new GameObject();
            f = go.AddComponent<Flowchart>();

            /*
            //here I create two blocks at random coordinats
            //have not yet figured out how to give them commands
            Vector2 pos1 = new Vector2(2, 1);
            Vector2 pos2 = new Vector2(2, 10);

            Block b1 = f.CreateBlock(pos1);
            Block b2 = f.CreateBlock(pos2);
            */
        }

        [Test]
        public void SimpleLockTest()
        {
            //checks if one first can successfully claim dialog
            Assert.AreEqual(global::DialogController.ClaimDialog(f), true);
            //checks if one indeed cannot claim the dialog whilst someone else has claimed it
            Assert.AreEqual(global::DialogController.ClaimDialog(f), false);
            //try it a few more times
            Assert.AreEqual(global::DialogController.ClaimDialog(f), false);
            Assert.AreEqual(global::DialogController.ClaimDialog(f), false);
            Assert.AreEqual(global::DialogController.ClaimDialog(f), false);
            //finaly, release lock and test if one now can get it
            global::DialogController.ReleaseDialog();
            Assert.AreEqual(global::DialogController.ClaimDialog(f), true);
        }
       

        //releases lock if it indeed is held
        [TearDown]
        public void ReleaseLock()
        {
            global::DialogController.ReleaseDialog();
        }

    }
}

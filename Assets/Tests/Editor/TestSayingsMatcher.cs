using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Fungus;

namespace Tests
{
    public class TestSayingsMathcer
    {
        private SayingMatcher sm;


        //tests if exception is thrown when constructing a SayingMatcher with nonmatching key, value lengths
        [Test]
        public void TestMatchingLength()
        {
            string[] a = { "a", "b" };
            string[] b = { "1", "2", "3" };
            try
            {
                sm = new SayingMatcher(a, b);

                Assert.Fail("Did not get expected exception ");
            }
            catch (System.ArgumentException e)
            {
                Assert.AreEqual(e.Message, "The sayings lists must be of equal length ");
            }

            string[] a1 = { "a", "b", "c" };
            string[] b1 = { "1", "2" };
            try
            {
                sm = new SayingMatcher(a1, b1);

                Assert.Fail("Did not get expected exception ");
            }
            catch (System.ArgumentException e)
            {
                Assert.AreEqual(e.Message, "The sayings lists must be of equal length ");
            }
        }

        [Test]
        public void InitiateSayingMatcher()
        {
            string[] a = { "a", "b", "c" };
            string[] b = { "1", "2", "3" };
            sm = new SayingMatcher(a, b);
            Assert.Pass("Saying matcher succesfully made ");
        }

        [Test]
        public void CheckCorrectAnswer()
        {
            string[] keys = {"ab", "cd", "ef", "gh"};
            string[] vals = { "12", "34", "56", "78" };
            sm = new SayingMatcher(keys, vals);

            Dictionary<string, string> d = new Dictionary<string, string>();
            for (int i = 0; i < keys.Length; i++)
            {
                d.Add(keys[i], vals[i]);
            }

            //checks if one correcyly is told 1 of 4 is correct
            int[] correctFraction1 = { 1, 4 };
            d["cd"] = "12";
            d["ef"] = "12";
            d["gh"] = "12";
            
            Assert.AreEqual(correctFraction1, sm.CheckCorrectAnswers(d));
            //checks if one correcyly is told 2 of 4 is correct
            int[] correctFraction2 = { 2, 4 };
            d["cd"] = "34";
            Assert.AreEqual(correctFraction2, sm.CheckCorrectAnswers(d));
            //checks if one correcyly is told 3 of 4 is correct
            int[] correctFraction3 = { 3, 4 };
            d["ef"] = "56";
            Assert.AreEqual(correctFraction3, sm.CheckCorrectAnswers(d));
            //checks if one correcyly is told 4 of 4 is correct
            int[] correctFraction4 = { 4, 4 };
            d["gh"] = "78";
            Assert.AreEqual(correctFraction4, sm.CheckCorrectAnswers(d));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayingMatcher
{
    //dictionary that maps from norwegian saying (keys) to foreign ones (values)
    private Dictionary<string, string> solutions;
    //length of soloutions
    private int length;

    public SayingMatcher(string[] norwegianSayings, string[] foreignSayings)
    {
        //throughs exception if the two arrays are of unequal length
        ThrowLengthException(norwegianSayings, foreignSayings);

        //initializes dictionary
        this.solutions = new Dictionary<string, string>();

        this.length = norwegianSayings.Length;
        //adds corresponding sayings to soloutions
        for (int i = 0; i < this.length; i++)
        {
            this.solutions.Add(norwegianSayings[i], foreignSayings[i]);
        }
    }

    //throws an exception if two string arrays have different lengths
    private void ThrowLengthException(string[] a, string[] b)
    {
        if (a.Length != b.Length)
        {
            throw new System.ArgumentException("The sayings lists must be of equal length ");
        }
    }

    //returns an array of two elements, that represent the fraction of correct matches
    public int[] CheckCorrectAnswers(Dictionary<string, string> answer)
    {
        int correctConnections = 0;
        foreach (string key in this.solutions.Keys)
        {
            if(this.solutions[key] == answer[key])
            {
                correctConnections += 1;
            }
        }
        int[] fractionCompleted = { correctConnections, solutions.Count };
        return fractionCompleted;
    }
}


using System.Collections.Generic;
using UnityEngine;

public static class RandomizeUniqueNumbers
{
    private static List<int> randomList = new List<int>();
    public static System.Object GenerateRandomList(int min, int max)
    {
        for (int i = 0; i < max; i++)
        {
            int numToAdd = Random.Range(min, max);
            while (randomList.Contains(numToAdd))
            {
                numToAdd = Random.Range(min, max);
            }
            randomList.Add(numToAdd);

        }
        return randomList;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomizer
{

    public static System.Object GenericRandom(object[] array)
    {

        return array[Random.Range(0, array.Length)];

    }

    public static System.Object RandomList(List<object> list)
    {

        return list[Random.Range(0, list.Count)];

    }

    public static int RandomInt(int start, int end)
    {
        return Random.Range(start, end);
    }
}

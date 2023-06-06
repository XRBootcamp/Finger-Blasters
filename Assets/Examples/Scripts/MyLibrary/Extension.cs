using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public static class Extension
{
    // Per settare tutti i child di un oggetto in un determinato layer
    public static void SetChildLayers(this Transform t, int layer)
    {
        for (int i = 0; i < t.childCount; i++)
        {
            Transform child = t.GetChild(i);
            child.gameObject.layer = layer;
            SetChildLayers(child, layer);
        }
    }

    // Lo uso per includere in una variabile sola piu elementi
    public static IEnumerable<Tuple<T1, T2, T3>> ZipSeveral3Element<T1, T2, T3>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third)
    {
        return first.Zip(second, (a, b) => new { a, b }).Zip(third, (t, c) => Tuple.Create(t.a, t.b, c));
    }

    public static IEnumerable<Tuple<T1, T2>> ZipSeveral2Element<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
    {
        return first.Zip(second, (a, b) => Tuple.Create(a, b));
    }

    // Coroutine che serve per ritardare l'inizio di un altro metodo che si vuole richiamare
    public static IEnumerator DelayRoutine(float delay, Action actionToDo)
    {
        yield return new WaitForSeconds(delay);
        actionToDo.Invoke();
    }

    public static void DumpToConsole(object obj)
    {
        var output = JsonConvert.SerializeObject(obj);
        Debug.Log(output);
    }

    public static Guid ToGuid(this string id)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] inputBytes = Encoding.Default.GetBytes(id);
        byte[] hashBytes = provider.ComputeHash(inputBytes);

        return new Guid(hashBytes);
    }
}
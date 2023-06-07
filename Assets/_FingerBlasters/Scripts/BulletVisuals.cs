using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVisuals : MonoBehaviour
{
    [SerializeField] public Dictionary<string, GameObject> bulletVisuals = new Dictionary<string, GameObject>();

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            bulletVisuals.Add(child.name, child.gameObject);
        }
    }

    public void SetActiveBulletVisuals(string key)
    {
        foreach (KeyValuePair<string, GameObject> bulletVisual in bulletVisuals)
        {
            if (bulletVisual.Key == key)
            {
                bulletVisual.Value.SetActive(true);
            }
            else
            {
                bulletVisual.Value.SetActive(false);
            }
        }
    }
}

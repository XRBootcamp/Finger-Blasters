using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGameManager : MonoBehaviour
{
    public static ShootGameManager instance;

    public GameObject playerReference;

    public Vector3 playerPos { get { return playerReference.transform.position; } }
    public Transform playerTransform { get { return playerReference.transform; } }

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) Destroy(this);
    }
}
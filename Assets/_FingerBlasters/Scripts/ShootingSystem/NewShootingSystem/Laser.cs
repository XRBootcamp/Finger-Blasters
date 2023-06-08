using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : GenericBullet
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Laser hit something" + other.gameObject.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Por_ObstacleRotation : MonoBehaviour
{
    public enum Rotation
    {
        X,
        Y,
        Z
    }

    public Rotation rotateOn;

    public float speed = 5f;

    void Update()
    {
        if (rotateOn == Rotation.X)
            transform.Rotate(speed, 0, 0);

        if (rotateOn == Rotation.Y)
            transform.Rotate(0, speed, 0);

        if (rotateOn == Rotation.Z)
            transform.Rotate(0, 0, speed);
    }
}
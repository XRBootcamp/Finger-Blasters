using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("RocketBullet"))
        {
            Debug.Log("SHIELD");
            Destroy(gameObject);
        }
    }
}

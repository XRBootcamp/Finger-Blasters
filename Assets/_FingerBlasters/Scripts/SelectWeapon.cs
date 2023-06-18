using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeapon : MonoBehaviour
{
    public GameObject ShootingRightHand;
    public GameObject bulletPrefab;
    public GameObject arrowPrefab;
    public GameObject riflePrefab;
    public GameObject rocketPrefab;

    // Start is called before the first frame update
    void Update()
    {
        if(ShootingRightHand != null)
        {
            Debug.Log("NOT NULL");
            if(ShootingRightHand.GetComponent<ShootManager>() != null)
            {
                bulletPrefab = ShootingRightHand.GetComponent<ShootManager>().bulletPrefab;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Crossbow"))
        {
            Debug.Log("TRIGGERED");
            ShootingRightHand.GetComponent<ShootManager>().bulletPrefab = arrowPrefab;
        } 
        
        if(other.CompareTag("Rifle"))
        {
            Debug.Log("TRIGGERED");
            ShootingRightHand.GetComponent<ShootManager>().bulletPrefab = riflePrefab;
        }
        
        if(other.CompareTag("Rocket"))
        {
            Debug.Log("TRIGGERED");
            ShootingRightHand.GetComponent<ShootManager>().bulletPrefab = rocketPrefab;
        }

        
    }
}

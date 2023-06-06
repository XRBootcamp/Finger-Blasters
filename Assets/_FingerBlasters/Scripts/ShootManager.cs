﻿using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [Header("SpawnTransform")]
    // Transform where the bullet have to be Instantiated
    public Transform hand;

    [Header("BulletPrefab")]
    // GameObject used as Bullet to Instatiate 
    [SerializeField] GameObject bulletPrefab;
    public float speed = 50f;

    [Header("Aim Circle")]
    public Transform gunTip;
    public Transform circle;

    private float maxDistance = 100f;
    public LayerMask whatCanCollide;

    // Enum where we set the mode of shooting the bullet
    public enum ShootMode
    {
        Auto,
        Single
    }

    [Header("ShootMethod")]
    // Choose the method of firing the bullets from Inspector
    public ShootMode shootMode;

    // Boolean to use in single ShootMode
    private bool hasShoot = false;

    // Float used to calculate the time need to fire the bullet, related to the bullet fireRate
    private float timeToFire = 0f;

    // Method to add in the Event of the gesture you want to make shoot
    public void OnShoot()
    {
        // Switch between the to modes
        switch (shootMode)
        {
            case ShootMode.Auto:
                Debug.Log("Shooting in Auto");
                if (Time.time >= timeToFire)
                {
                    timeToFire = Time.time + 1f / bulletPrefab.GetComponent<ProjectileScript>().fireRate;
                    Shoot();
                }
                break;

            case ShootMode.Single:
                if (!hasShoot)
                {
                    hasShoot = true;
                    Debug.Log("Shooting in Single");
                    Shoot();
                }
                break;
        }
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(gunTip.position, gunTip.forward, out hit, maxDistance, whatCanCollide))
        {
            circle.gameObject.SetActive(true);
            circle.position = (hit.point);
            circle.rotation = Quaternion.LookRotation(hit.normal);
        }
        else
        {
            circle.gameObject.SetActive(false);
        }
    }

    private void Shoot()
    {
        // In the End we will going to shoot a bullet
        GameObject bullet = Instantiate(bulletPrefab, hand.position, Quaternion.identity);
        bullet.transform.localRotation = hand.rotation;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * speed * 2f); //Set the speed of the projectile by applying force to the rigidbody
    }

    // Method to put in the Event when the gesture are not recognized
    public void StopShoot()
    {
        hasShoot = false;
        Debug.Log("Stop Shooting");
    }

    public void SetMaxDistance(float distance)
    {
        maxDistance = distance;
    }
}
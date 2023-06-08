using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float fireRate;

    public bool isActive;
    
    private float fireRateTimer;

    private void Update()
    {
        if (!isActive) return;

        fireRateTimer += Time.deltaTime;
        if(fireRateTimer >= 1/fireRate)
        {
            Shoot();
            fireRateTimer = 0;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedGun : MonoBehaviour
{
    public enum ActiveAmmo
    {
        Arrow,
        BulletPistol,
        Rocket,
        Laser,
        BulletRifle
    }

    public ActiveAmmo activeAmmo;

    //create a dictionary with all of the bullet type prefabs 

    [SerializeField] GameObject arrowPrefab;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletPrefab2;
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] GameObject laserPrefab;

    [SerializeField] Gun gun;

    private void Awake() 
    {
        gun = GetComponent<Gun>();
        SetActiveAmmo(ActiveAmmo.Arrow);
    }

    public void SetActiveAmmo(ActiveAmmo ammo)
    {
        activeAmmo = ammo;
        SetBulletPrefab();
    }

    private void Update() 
    {
        SetBulletPrefab();
    }

    private void SetBulletPrefab()
    {
        if(activeAmmo == ActiveAmmo.Arrow)
        {
            gun.bulletPrefab = arrowPrefab;
        }
        else if(activeAmmo == ActiveAmmo.BulletPistol)
        {
            gun.bulletPrefab = bulletPrefab;
        }
        else if(activeAmmo == ActiveAmmo.Rocket)
        {
            gun.bulletPrefab = rocketPrefab;
        }
        else if(activeAmmo == ActiveAmmo.Laser)
        {
            gun.bulletPrefab = laserPrefab;
        }
        else if(activeAmmo == ActiveAmmo.BulletRifle)
        {
            gun.bulletPrefab = bulletPrefab2;
        }
    }
}

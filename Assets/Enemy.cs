using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;        // Reference to the player object
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawn;   // Reference to the bullet spawn point

    public float rotationSpeed = 5f;
    public float fireRate = 2f;
    public float bulletSpeed = 10f;
    public float bulletForce = 500f;
    private float nextFireTime;

    private void Start()
    {
        nextFireTime = Time.time;
    }

    private void Update()
    {
        // Look at the player
        Vector3 direction = player.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        // Shoot towards the player
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Set the bullet's speed
        bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed;

        // Apply force to the bullet (optional)
        bulletRigidbody.AddForce(bullet.transform.forward * bulletForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("RifleBullet"))
        {
            Debug.Log("ROBOT SHOT");
            transform.gameObject.SetActive(false);
        }
    }
}

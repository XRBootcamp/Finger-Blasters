using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericBullet : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed;
    [SerializeField] private float bulletLifeTime;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletKnockback;
    [SerializeField] protected Rigidbody rb;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, bulletLifeTime);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //add force to the bullet to make a natural arc
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}

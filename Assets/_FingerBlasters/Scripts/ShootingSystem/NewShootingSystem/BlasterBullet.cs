using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterBullet : GenericBullet
{
    [SerializeField] private ParticleSystem explosionParticles;

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
        Destroy(gameObject);
    }

    private void OnDestroy() 
    {
        Instantiate(explosionParticles, transform.position, transform.rotation);
    }
}


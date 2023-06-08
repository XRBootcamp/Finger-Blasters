using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : GenericBullet
{
    [SerializeField] private ParticleSystem rocketJetParticles;
    [SerializeField] private ParticleSystem rocketWindParticles;
    [SerializeField] private ParticleSystem rocketExplosionParticles;
    
    protected override void Start()
    {
        rocketJetParticles.Play();
        rocketWindParticles.Play();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    protected override void Update()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        base.Update();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Rocket hit something" + other.gameObject.name);
        rocketJetParticles.Stop();
        rocketWindParticles.Stop();
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForEndOfFrame();
        rocketExplosionParticles.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnDestroy() {

    }



}

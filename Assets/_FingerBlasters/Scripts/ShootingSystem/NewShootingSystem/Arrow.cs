using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : GenericBullet
{
    [SerializeField] private bool isStuck;
    [SerializeField] private ParticleSystem arrowWindParticles;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        arrowWindParticles.Play();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isStuck) return;    
        base.Update();
        //perform a dotween curve to move the arrow gradually towards the ground
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Arrow hit something" + other.gameObject.name);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        isStuck = true;
        arrowWindParticles.Stop();

       
       //if the arrows hits a target
        if(other.gameObject.CompareTag("Target"))
        {
            //add functionality here
        }
    }
}

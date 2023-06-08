using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStats : MonoBehaviour
{
    //public GameObject parent;

    public GameObject explotionParticle;

    public Vector3 explotionOffset;

    private NPCSpawner spawner;

    public float maxHealth = 100;
    public float currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void SetSpawner(NPCSpawner setSpawner)
    {
        spawner = setSpawner;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            GameObject impactP = Instantiate(explotionParticle, (transform.position + explotionOffset), Quaternion.identity);

            if (spawner != null)
            {
                spawner.NPCSpawned.Remove(gameObject);
                spawner.InitializeSpawner();
            }
            
            Destroy(gameObject);
            Destroy(impactP, 5.0f);

        }

        healthBar.SetHealth(currentHealth);
    }
}

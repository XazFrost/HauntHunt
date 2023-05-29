using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ghost : MonoBehaviour
{
    public float health = 50; // ghost's health
    private KillCounter killCounter; // reference to the KillCounter script
    public AudioClip ghostHit;

    private void Start()
    {
        // Find the KillCounter component in the scene
        killCounter = FindObjectOfType<KillCounter>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        GetComponent<AudioSource>().PlayOneShot(ghostHit);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Increase the kill count in the KillCounter script
        killCounter.HandleGhostDeath();

        // add death effect
        Destroy(gameObject);
    }
}

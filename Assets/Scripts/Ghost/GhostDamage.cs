using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamage : MonoBehaviour
{
    public float damage = 10f;
    private HitVignette vignette;

    void Start()
    {
        vignette = Camera.main.GetComponentInChildren<HitVignette>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
            vignette.Hit();
            
        }
    }
}

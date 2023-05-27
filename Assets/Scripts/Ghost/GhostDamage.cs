using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamage : MonoBehaviour
{
    public float damage = 10f;
    public HitVignette vignette;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
            vignette.Hit();
            
        }
    }
}

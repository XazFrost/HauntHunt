using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public float damage = 5f;
    void OnCollisionEnter(Collision collision)
    {
        Ghost ghost = collision.gameObject.GetComponent<Ghost>();
        if (ghost != null)
        {
            ghost.TakeDamage(damage);
        }

        // Hit Effect
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);

        Destroy(gameObject);
    }
}

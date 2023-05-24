using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public float damage = 5f;
    public float lifetime = 4f;
    private float time = 0f;
    void OnTriggerEnter(Collider collider)
    {
        Ghost ghost = collider.gameObject.GetComponent<Ghost>();
        if (ghost != null)
        {
            ghost.TakeDamage(damage);
        }

        // Hit Effect
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);

        Destroy(gameObject);
    }

    void Update()
    {
        if (time > lifetime)
        {
            Destroy(gameObject);
        }
        time += Time.deltaTime;
    }
}

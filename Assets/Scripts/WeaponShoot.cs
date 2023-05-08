using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public int damage = 10; // урон оружия

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // нанести урон приведению
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red, 10f);
                Ghost ghost = hit.collider.GetComponent<Ghost>();
                if (ghost != null)
                {
                    ghost.TakeDamage(damage);
                }

                

            }
        }
    }
}

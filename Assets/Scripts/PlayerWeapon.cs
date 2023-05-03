using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Weapon weapon; // ������ �� ��������� ������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // ������� ���� ����������
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Ghost ghost = hit.collider.GetComponent<Ghost>();
                if (ghost != null)
                {
                    weapon.Hit(ghost);
                }

                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red, 10f);

            }
        }
    }
}

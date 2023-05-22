using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float health = 50; // �������� ����������

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // �������� ������ ������
        Destroy(gameObject);
    }
}

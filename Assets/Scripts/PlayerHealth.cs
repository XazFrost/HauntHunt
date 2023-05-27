using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public HealthBar healthBar;

    void Start()
    {
        healthBar.ChangeMaxHealth(maxHealth);
    }

    public void SetHealth(float _health)
    {
        health = _health;
        UpdateHealth();
    }

    public void ChangeHealth(float _health)
    {
        health += _health;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        health = Mathf.Clamp(health, 0f, maxHealth);
        healthBar.ChangeHealthBar(health);
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        SceneManager.LoadScene("Menu");
    }
}

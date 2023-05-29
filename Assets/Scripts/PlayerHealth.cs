using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public HealthBar _healthBar;
    public AudioClip playerHit;

    void Start()
    {
        if (_healthBar != null)
        {
            _healthBar.ChangeHealthBar(health);
            _healthBar.ChangeMaxHealth(maxHealth);
        }
    }

    public void SetHealth(float _health)
    {
        health = _health;
        UpdateHealth();
    }

    public void ChangeHealth(float _health)
    {
        health += _health;
        if (_health < 0)
        {
            GetComponent<AudioSource>().PlayOneShot(playerHit);
        }
        UpdateHealth();
    }

    void UpdateHealth()
    {
        health = Mathf.Clamp(health, 0f, maxHealth);
        _healthBar.ChangeHealthBar(health);
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

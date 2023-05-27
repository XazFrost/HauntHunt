using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBar;
    void Start()
    {
        healthBar = gameObject.GetComponent<Slider>();
    }

    public void ChangeHealthBar(float value)
    {
        healthBar.value = value;
    }

    public void ChangeMaxHealth(float maxHealth)
    {
        healthBar.maxValue = maxHealth;
    }
}

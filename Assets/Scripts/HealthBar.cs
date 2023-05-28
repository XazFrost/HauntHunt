using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBar;
    void Awake()
    {
        healthBar = gameObject.GetComponent<Slider>();
    }

    public void ChangeHealthBar(float _value)
    {
        healthBar.value = _value;
    }

    public void ChangeMaxHealth(float maxHealth)
    {
        healthBar.maxValue = maxHealth;
    }
}

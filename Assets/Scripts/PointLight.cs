using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLight : MonoBehaviour
{
    public Light pointLight;
    public float minIntensity = 0.5f; // Минимальная интенсивность
    public float maxIntensity = 1.5f; // Максимальная интенсивность
    public float changeDuration = 2f; // Продолжительность смены интенсивности
    public float smoothness = 1f; // Плавность смены интенсивности
    public float changePeriod = 4f; // Периодичность смены интенсивности

    private float targetIntensity;
    private float intensityVelocity;
    private float timer;

    private void Start()
    {
        // Установка начальных значений
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        pointLight.intensity = targetIntensity;
        timer = changePeriod;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Проверка, нужно ли сменить интенсивность
        if (timer >= changePeriod)
        {
            timer = 0f;
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }

        // Плавное изменение интенсивности
        pointLight.intensity = Mathf.SmoothDamp(pointLight.intensity, targetIntensity, ref intensityVelocity, changeDuration, smoothness);
    }
}

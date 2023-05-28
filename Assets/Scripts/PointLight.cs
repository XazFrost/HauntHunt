using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLight : MonoBehaviour
{
    public Light pointLight;
    public float minIntensity = 0.5f; // ����������� �������������
    public float maxIntensity = 1.5f; // ������������ �������������
    public float changeDuration = 2f; // ����������������� ����� �������������
    public float smoothness = 1f; // ��������� ����� �������������
    public float changePeriod = 4f; // ������������� ����� �������������

    private float targetIntensity;
    private float intensityVelocity;
    private float timer;

    private void Start()
    {
        // ��������� ��������� ��������
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        pointLight.intensity = targetIntensity;
        timer = changePeriod;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // ��������, ����� �� ������� �������������
        if (timer >= changePeriod)
        {
            timer = 0f;
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }

        // ������� ��������� �������������
        pointLight.intensity = Mathf.SmoothDamp(pointLight.intensity, targetIntensity, ref intensityVelocity, changeDuration, smoothness);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadSlider : MonoBehaviour
{
    GameObject mainCamera, player;
    public Vector3 offset;
    Slider slider;
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        transform.rotation = mainCamera.transform.rotation;
        transform.position = player.transform.position + offset;
    }

    public void SliderUpdate(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}

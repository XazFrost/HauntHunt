using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvasOnTrigger : MonoBehaviour
{
    public Canvas canvasToShow; // ссылка на Canvas, который нужно сделать видимым
    public GameObject firstPanel; // ссылка на первую панель
    public GameObject secondPanel; // ссылка на вторую панель

    private bool isInTrigger; // флаг, указывающий, находимся ли мы в триггере

    private void Start()
    {
        canvasToShow.enabled = false; // изначально отключаем видимость Canvas при запуске игры
        firstPanel.SetActive(true); // включаем первую панель
        secondPanel.SetActive(false); // выключаем вторую панель
    }

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleSecondPanel();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasToShow.enabled = true; // включаем Canvas при вхождении игрока в коллайдер
            isInTrigger = true; // устанавливаем флаг в true
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasToShow.enabled = false; // выключаем Canvas при выходе игрока из коллайдера
            isInTrigger = false; // устанавливаем флаг в false
            firstPanel.SetActive(true); // включаем первую панель
            secondPanel.SetActive(false); // выключаем вторую панель
        }
    }

    private void ToggleSecondPanel()
    {
        if (secondPanel.activeSelf)
        {
            secondPanel.SetActive(false); // выключаем вторую панель
        }
        else
        {
            secondPanel.SetActive(true); // включаем вторую панель
        }
    }
}

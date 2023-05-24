using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public string Menu; // Имя сцены меню выбора уровня

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Загрузить сцену меню выбора уровня
            SceneManager.LoadScene("Menu");
        }
    }
}

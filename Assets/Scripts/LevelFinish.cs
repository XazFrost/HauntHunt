using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public string Menu; // ��� ����� ���� ������ ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ��������� ����� ���� ������ ������
            SceneManager.LoadScene("Menu");
        }
    }
}

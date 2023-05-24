using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvasOnTrigger : MonoBehaviour
{
    public Canvas canvasToShow; // ������ �� Canvas, ������� ����� ������� �������
    public GameObject firstPanel; // ������ �� ������ ������
    public GameObject secondPanel; // ������ �� ������ ������

    private bool isInTrigger; // ����, �����������, ��������� �� �� � ��������

    private void Start()
    {
        canvasToShow.enabled = false; // ���������� ��������� ��������� Canvas ��� ������� ����
        firstPanel.SetActive(true); // �������� ������ ������
        secondPanel.SetActive(false); // ��������� ������ ������
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
            canvasToShow.enabled = true; // �������� Canvas ��� ��������� ������ � ���������
            isInTrigger = true; // ������������� ���� � true
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasToShow.enabled = false; // ��������� Canvas ��� ������ ������ �� ����������
            isInTrigger = false; // ������������� ���� � false
            firstPanel.SetActive(true); // �������� ������ ������
            secondPanel.SetActive(false); // ��������� ������ ������
        }
    }

    private void ToggleSecondPanel()
    {
        if (secondPanel.activeSelf)
        {
            secondPanel.SetActive(false); // ��������� ������ ������
        }
        else
        {
            secondPanel.SetActive(true); // �������� ������ ������
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public Canvas inventoryCanvas; // ������ �� ������ Canvas ���������
    public KeyCode inventoryKey = KeyCode.I; // �������, ������� ���������/��������� ���������

    private bool isInventoryOpen = false; // ����, ������������, ������ �� ��������� � ������ ������

    void Update()
    {
        // ���������, ������ �� ������� ��������/�������� ���������
        if (Input.GetKeyDown(inventoryKey))
        {
            // ���� ��������� ��� ������, �� ��������� ���
            if (isInventoryOpen)
            {
                inventoryCanvas.gameObject.SetActive(false);
                isInventoryOpen = false;
            }
            // ���� ��������� ������, �� ��������� ���
            else
            {
                inventoryCanvas.gameObject.SetActive(true);
                isInventoryOpen = true;
            }
        }
    }
}

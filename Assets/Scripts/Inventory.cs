using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Inventory_Item Item;
    public int inventorySize = 10; // ������ ���������
    public Image[] itemImages; // ������ �������� ��������� � ������
    public Inventory_Item[] items; // ������ ��������� � ������

    public void AddItem(Inventory_Item item)
    {
        // ���� ������ ���� � ��������� ������� � ���������
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                itemImages[i].sprite = item.itemImage;
                itemImages[i].enabled = true;
                return;
            }
        }
    }

    public void RemoveItem(Inventory_Item item)
    {
        // ���� ���� � ������ ��������� � ������� ��� �� ���������
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    public bool ContainsItem(Inventory_Item item)
    {
        // ���������, ���� �� ������ ������� � ���������
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                return true;
            }
        }
        return false;
    }
}

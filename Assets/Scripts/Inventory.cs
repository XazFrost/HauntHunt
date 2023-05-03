using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Inventory_Item Item;
    public int inventorySize = 10; // Размер инвентаря
    public Image[] itemImages; // Массив картинок предметов в слотах
    public Inventory_Item[] items; // Массив предметов в слотах

    public void AddItem(Inventory_Item item)
    {
        // Ищем пустой слот и добавляем предмет в инвентарь
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
        // Ищем слот с нужным предметом и удаляем его из инвентаря
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
        // Проверяем, есть ли нужный предмет в инвентаре
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

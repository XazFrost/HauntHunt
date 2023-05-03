using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public Canvas inventoryCanvas; // ссылка на объект Canvas инвентаря
    public KeyCode inventoryKey = KeyCode.I; // клавиша, которая открывает/закрывает инвентарь

    private bool isInventoryOpen = false; // флаг, отображающий, открыт ли инвентарь в данный момент

    void Update()
    {
        // проверяем, нажата ли клавиша открытия/закрытия инвентаря
        if (Input.GetKeyDown(inventoryKey))
        {
            // если инвентарь уже открыт, то закрываем его
            if (isInventoryOpen)
            {
                inventoryCanvas.gameObject.SetActive(false);
                isInventoryOpen = false;
            }
            // если инвентарь закрыт, то открываем его
            else
            {
                inventoryCanvas.gameObject.SetActive(true);
                isInventoryOpen = true;
            }
        }
    }
}

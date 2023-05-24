using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBarInventory : MonoBehaviour
{
    // Объект у которого дети являются слотами
    public Transform hotBarParent;
    public InventoryManager inventoryManager;
    public int currentHotBarID = 0;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    //public Text healthText;
    public InventorySlot activeSlot = null;

    // Update is called once per frame
    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");
        // Используем колесико мышки
        if (mw > 0.1)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            hotBarParent.GetChild(currentHotBarID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки вперед и наше число currentHotBarID равно последнему слоту, то выбираем наш первый слот (первый слот считается нулевым)
            if (currentHotBarID >= hotBarParent.childCount-1)
            {
                currentHotBarID = 0;
            }
            else
            {
                // Прибавляем к числу currentHotBarID единичку
                currentHotBarID++;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            hotBarParent.GetChild(currentHotBarID).GetComponent<Image>().sprite = selectedSprite;
            activeSlot = hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>();
            // Что то делаем с предметом:

        }
        if (mw < -0.1)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            hotBarParent.GetChild(currentHotBarID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки назад и наше число currentHotBarID равно 0, то выбираем наш последний слот
            if (currentHotBarID <= 0)
            {
                currentHotBarID = hotBarParent.childCount-1;
            }
            else
            {
                // Уменьшаем число currentHotBarID на 1
                currentHotBarID--;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            hotBarParent.GetChild(currentHotBarID).GetComponent<Image>().sprite = selectedSprite;
            activeSlot = hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>();
            // Что то делаем с предметом:
            
        }
        // Используем цифры
        for(int i = 0; i < hotBarParent.childCount; i++)
        {
            // если мы нажимаем на клавиши 1 по 5 то...
            if (Input.GetKeyDown((i + 1).ToString())) {
                // проверяем если наш выбранный слот равен слоту который у нас уже выбран, то
                if (currentHotBarID == i)
                {
                    // Ставим картинку "selected" на слот если он "not selected" или наоборот
                    if (hotBarParent.GetChild(currentHotBarID).GetComponent<Image>().sprite == notSelectedSprite)
                    {
                        hotBarParent.GetChild(currentHotBarID).GetComponent<Image>().sprite = selectedSprite;
                        activeSlot = hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>();
                    }
                    else
                    {
                        hotBarParent.GetChild(currentHotBarID).GetComponent<Image>().sprite = notSelectedSprite;
                        activeSlot = null;
                    }
                }
                // Иначе мы убираем свечение с предыдущего слота и светим слот который мы выбираем
                else
                {
                    hotBarParent.GetChild(currentHotBarID).GetComponent<Image>().sprite = notSelectedSprite;
                    currentHotBarID = i;
                    hotBarParent.GetChild(currentHotBarID).GetComponent<Image>().sprite = selectedSprite;
                    activeSlot = hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>();
                }
            }
        }

        /*
        // Используем предмет по нажатию на левую кнопку мыши
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>().item != null)
            {
                if (hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>().item.isConsumeable && !inventoryManager.isOpened && hotBarParent.GetChild(currentHotBarID).GetComponent<Image>().sprite == selectedSprite)
                {
                    // Применяем изменения к здоровью (будущем к голоду и жажде) 
                    ChangeCharacteristics();

                    if (hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>().amount <= 1)
                    {
                        hotBarParent.GetChild(currentHotBarID).GetComponentInChildren<DragAndDropItem>().NullifySlotData();
                    }
                    else
                    {
                        hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>().amount--;
                        hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>().itemAmountText.text = hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>().amount.ToString();
                    }
                }
            }
        }
        */
    }
    /*
    private void ChangeCharacteristics()
    {
        // Если здоровье + добавленное здоровье от предмета меньше или равно 100, то делаем вычисления... 
        if(int.Parse(healthText.text) + hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>().item.changeHealth <= 100)
        {
            float newHealth = int.Parse(healthText.text) + hotBarParent.GetChild(currentHotBarID).GetComponent<InventorySlot>().item.changeHealth;
            healthText.text = newHealth.ToString();
        }
        // Иначе, просто ставим здоровье на 100
        else
        {
            healthText.text = "100";
        }
    }
    */
}

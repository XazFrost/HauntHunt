using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
/// IPointerDownHandler - ������ �� ��������� ����� �� ������� �� ������� ����� ���� ������
/// IPointerUpHandler - ������ �� ����������� ����� �� ������� �� ������� ����� ���� ������
/// IDragHandler - ������ �� ��� �� ����� �� �� ������� ����� �� �������
public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public InventorySlot oldSlot;
    private Transform player;
    public HotBarInventory hotBarInventory;

    private void Start()
    {
        //��������� ��� "PLAYER" �� ������� ���������!
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // ������� ������ InventorySlot � ����� � ��������
        oldSlot = transform.GetComponentInParent<InventorySlot>();

        hotBarInventory = GameObject.FindGameObjectWithTag("HotBar").GetComponent<HotBarInventory>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        // ���� ���� ������, �� �� �� ��������� �� ��� ���� return;
        if (oldSlot.isEmpty)
            return;
        GetComponent<RectTransform>().position += new Vector3(eventData.delta.x, eventData.delta.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (oldSlot.isEmpty)
            return;
        //������ �������� ����������
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.75f);
        // ������ ��� ����� ������� ������ �� ������������ ��� ��������
        GetComponentInChildren<Image>().raycastTarget = false;
        // ������ ��� DraggableObject �������� InventoryPanel ����� DraggableObject ��� ��� ������� ������� ���������
        transform.SetParent(transform.parent.parent);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (oldSlot.isEmpty)
            return;
        // ������ �������� ����� �� ����������
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1f);
        // � ����� ����� ����� ����� �� ������
        GetComponentInChildren<Image>().raycastTarget = true;

        //��������� DraggableObject ������� � ���� ������ ����
        transform.SetParent(oldSlot.transform);
        transform.position = oldSlot.transform.position;
        //���� ����� �������� ��� �������� �� ����� UIPanel, ��...
        if (eventData.pointerCurrentRaycast.gameObject.name == "UIPanels")
        {
            // ������ �������� �� ��������� - ������� ������ ������ ����� ����������
            GameObject itemObject = Instantiate(oldSlot.item.itemPrefab, player.position + Vector3.up + player.forward, Quaternion.identity);
            // ������������� ���������� �������� ����� ����� ���� � �����
            itemObject.GetComponent<Item>().amount = oldSlot.amount;
            // ������� �������� InventorySlot
            NullifySlotData();
            // ��������� ������� � ����� ����� �������� ����
            hotBarInventory.activeSlotUpdate();
        }
        else if(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>() != null)
        {
            //���������� ������ �� ������ ����� � ������
            ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>());
            // ��������� ������� � ����� ����� �������� ����
            hotBarInventory.activeSlotUpdate();
        }
       
    }
    public void NullifySlotData()
    {
        // ������� �������� InventorySlot
        oldSlot.item = null;
        oldSlot.amount = 0;
        oldSlot.isEmpty = true;
        oldSlot.IconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        oldSlot.IconGO.GetComponent<Image>().sprite = null;
        oldSlot.itemAmountText.text = "";
    }
    void ExchangeSlotData(InventorySlot newSlot)
    {
        // �������� ������ ������ newSlot � ��������� ����������
        ItemScriptableObject item = newSlot.item;
        int amount = newSlot.amount;
        bool isEmpty = newSlot.isEmpty;
        GameObject iconGO = newSlot.IconGO;
        TMP_Text itemAmountText = newSlot.itemAmountText;

        // �������� �������� newSlot �� �������� oldSlot
        newSlot.item = oldSlot.item;
        newSlot.amount = oldSlot.amount;
        if (oldSlot.isEmpty == false)
        {
            newSlot.SetIcon(oldSlot.IconGO.GetComponent<Image>().sprite);
            newSlot.itemAmountText.text = oldSlot.amount.ToString();
        }
        else
        {
            newSlot.IconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            newSlot.IconGO.GetComponent<Image>().sprite = null;
            newSlot.itemAmountText.text = "";
        }
        
        newSlot.isEmpty = oldSlot.isEmpty;

        // �������� �������� oldSlot �� �������� newSlot ����������� � ����������
        oldSlot.item = item;
        oldSlot.amount = amount;
        if (isEmpty == false)
        {
            oldSlot.SetIcon(item.icon);
            oldSlot.itemAmountText.text = amount.ToString();
        }
        else
        {
            oldSlot.IconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            oldSlot.IconGO.GetComponent<Image>().sprite = null;
            oldSlot.itemAmountText.text = "";
        }
        
        oldSlot.isEmpty = isEmpty;
    }
}

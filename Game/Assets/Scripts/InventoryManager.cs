using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;
    public GameObject crosshair;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    public float reachDistance = 3f;
    private Camera mainCamera;

    private void Awake()
    {
        UIPanel.SetActive(true);
    }

    void Start()
    {
        mainCamera = Camera.main;

        // Проверим, что камера не null
        if (mainCamera == null)
        {
            Debug.LogError("Main camera is not found! Please ensure you have a camera tagged as 'MainCamera'.");
            return;
        }

        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            InventorySlot slot = inventoryPanel.GetChild(i).GetComponent<InventorySlot>();
            if (slot != null)
            {
                slots.Add(slot);
            }
        }

        UIPanel.SetActive(false);
    }

    void Update()
    {
        if (mainCamera == null)
        {
            return;  // Защитный код на случай, если Start() не обнаружил камеры
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;
            UIPanel.SetActive(isOpened);
            crosshair.SetActive(!isOpened);
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Item hitItem = hit.collider.gameObject.GetComponent<Item>();
                if (hitItem != null)
                {
                    AddItem(hitItem.item, hitItem.amount);
                    Destroy(hit.collider.gameObject);
                }
            }

            Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.green);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.red);
        }
    }

    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                slot.amount += _amount;
                slot.itemAmountText.text = slot.amount.ToString();
                return;
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
        }
    }
}
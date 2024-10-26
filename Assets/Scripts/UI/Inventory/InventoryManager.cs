using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField]
    private GameObject inventoryPanel;

    private bool visibleInventoryPanel;

    [SerializeField]
    private RectTransform inventorySlotsPanel;

    [SerializeField]
    private ItemSlot itemSlotPrefab;

    [SerializeField]
    private int slotCount;

    private List<ItemSlot> itemSlots = new List<ItemSlot>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        inventoryPanel.SetActive(visibleInventoryPanel);
        InitializeSlots();
    }

    public void InitializeSlots()
    {
        for (var i = 0; i < slotCount; i++)
        {
            var newItemSlot = Instantiate(itemSlotPrefab, inventorySlotsPanel);
            newItemSlot.ClearSlot();
            itemSlots.Add(newItemSlot);
        }
    }

    public void OnToggle(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            visibleInventoryPanel = !visibleInventoryPanel;
            inventoryPanel.SetActive(visibleInventoryPanel);

            Time.timeScale = visibleInventoryPanel ? 0 : 1;
        }
    }

    public void AddItem(ItemDataSO itemData, int quantity)
    {
        foreach (var slot in itemSlots)
        {
            if (slot.itemData != null && slot.itemData == itemData)
            {
                slot.AddQuantity(quantity);
                return;
            }
        }

        foreach (var slot in itemSlots)
        {
            if (slot.itemData == null)
            {
                slot.SetItem(itemData, quantity);
                return;
            }
        }

        Debug.Log("Нет доступных слотов для добавления предмета: " + itemData.Name);
    }
}

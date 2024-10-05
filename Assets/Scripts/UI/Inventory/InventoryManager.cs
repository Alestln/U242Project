using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel;

    private bool visibleInventoryPanel;

    [SerializeField]
    private RectTransform inventorySlotsPanel;

    [SerializeField]
    private ItemSlot itemSlotPrefab;

    Dictionary<string, ItemSlot> inventorySlots = new Dictionary<string, ItemSlot>();

    private void Start()
    {
        inventoryPanel.SetActive(visibleInventoryPanel);
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

    public void AddItem(Item item)
    {
        if (inventorySlots.TryGetValue(item.Name, out ItemSlot existingItem))
        {
            existingItem.AddQuantity(item.Quantity);
        }
        else
        {
            ItemSlot newItemSlot = Instantiate(itemSlotPrefab, inventorySlotsPanel);
            newItemSlot.AddItem(item);
            inventorySlots.Add(item.Name, newItemSlot);
        }
    }
}

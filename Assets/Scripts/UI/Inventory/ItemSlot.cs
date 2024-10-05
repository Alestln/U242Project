using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private TMP_Text quantityText;

    private Item storedItem;

    public void AddItem(Item item)
    {
        storedItem = item;
        UpdateSlot();
    }

    private void UpdateSlot()
    {
        if (storedItem is not null)
        {
            itemImage.sprite = storedItem.GetComponent<SpriteRenderer>().sprite;
            quantityText.text = storedItem.Quantity.ToString();

        }
    }

    public void AddQuantity(int quantity)
    {
        if (storedItem is not null)
        {
            storedItem.Quantity += quantity;
            UpdateSlot();
        }
    }
}

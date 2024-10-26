using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private TMP_Text quantityText;

    public ItemDataSO itemData;

    public void SetItem(ItemDataSO itemData, int quantity)
    {
        this.itemData = itemData;

        itemImage.sprite = this.itemData.Sprite;
        itemImage.enabled = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
    }

    public void ClearSlot()
    {
        itemData = null;
        itemImage.enabled = false;
        quantityText.enabled = false;
    }

    public void AddQuantity(int quantity)
    {
        if (itemData != null)
        {
            int currentQuantity = int.Parse(quantityText.text);
            currentQuantity += quantity;
            quantityText.text = currentQuantity.ToString();
        }
    }
}

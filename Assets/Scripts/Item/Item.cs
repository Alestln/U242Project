using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemDataSO itemData;

    [SerializeField]
    private int Quantity;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = itemData.Sprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            InventoryManager.Instance.AddItem(itemData, Quantity);

            Destroy(gameObject);
        }
    }
}

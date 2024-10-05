using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private InventoryManager inventoryManager;

    public string Name { get; set; }
    public int Quantity { get; set; }

    private void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer is not null)
        {
            Name = spriteRenderer.sprite.name;
        }

        Quantity = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();

        if (player is not null)
        {
            inventoryManager.AddItem(this);
            Destroy(gameObject);
        }
    }
}

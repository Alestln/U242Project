using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Inventory/ItemData")]
public class ItemDataSO : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public string Description;
}
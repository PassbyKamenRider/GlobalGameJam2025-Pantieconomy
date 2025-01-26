using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")] 
public class Item: ScriptableObject
{
    public Material[] materials;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
}
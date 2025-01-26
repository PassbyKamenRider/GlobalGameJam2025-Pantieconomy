using UnityEngine;


[CreateAssetMenu(fileName = "New MarketItem", menuName = "MarketItem/Create New MarketItem")]
public class MarketItem : ScriptableObject
{
    public float price;
    public string itemName;
    public int quantity;
    public Sprite itemIcon;
}
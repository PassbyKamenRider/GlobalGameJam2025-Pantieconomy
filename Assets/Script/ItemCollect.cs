using System.Xml.Serialization;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    public Item item;


    void Collect()
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject);
    }
}

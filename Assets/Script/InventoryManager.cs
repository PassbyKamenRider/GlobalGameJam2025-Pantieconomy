using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public List<GameObject> listedGameObj = new List<GameObject>();
    public Transform ItemContent;
    public GameObject InventoryItem;
    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }


    public void ListItem()
    {

        foreach (Transform item in ItemContent)
        {
            if (item != null)
            {
                Destroy(item.gameObject);
            }
        }


        foreach (Item item in Items)
        {
            if (item != null)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);

                var Name = obj.transform.Find("ItemName").GetComponent<Text>();
                
                Name.text = item.itemName;

                var Icon = obj.transform.Find("ItemIcon").GetComponent<Image>();

                Icon.sprite = item.itemIcon;
            }
        }
    }

    
}

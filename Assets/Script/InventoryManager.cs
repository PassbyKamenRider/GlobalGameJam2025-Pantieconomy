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
        foreach (Item item in Items)
        {
            if (item != null)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var itemName = obj.transform.Find("Item/ItemName").GetComponent<Text>();
                var itemIcon = obj.transform.Find("Item/ItemIcon").GetComponent<Image>();

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
                listedGameObj.Add(obj);

            }
        }
    }

    public void DeleteItems()
    {
        foreach (GameObject obj in listedGameObj)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }
}

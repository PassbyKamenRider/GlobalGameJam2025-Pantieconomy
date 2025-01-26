using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.Linq;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Dictionary<Item, int> items = new();
    public Transform ItemContent;
    public GameObject InventoryItem;
    public Item[] commonItems, uncommonItems, rareItems, epicItems, legendaryItems;
    private void Awake()
    {
        Instance = this;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < uncommonItems.Length; i++)
            {
                AddItem(uncommonItems[i]);
            }
            ListItem();
        }
    }

    public void AddItem(Item item)
    {
        if (items.ContainsKey(item))
        {
            items[item] += 1;
        }
        else
        {
            items[item] = 1;
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
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

        foreach (var i in items)
        {
            if (i.Key != null)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);

                var Name = obj.transform.Find("ItemName").GetComponent<Text>();
                
                Name.text = i.Value.ToString();

                var Icon = obj.transform.Find("ItemIcon").GetComponent<Image>();

                Icon.sprite = i.Key.itemIcon;
            }
        }
    }

    
}

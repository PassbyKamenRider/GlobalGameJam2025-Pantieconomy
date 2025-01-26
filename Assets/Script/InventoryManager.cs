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

    public void AddRandItem(int rarity)
    {
        Item item = null;

        switch (rarity)
        {
            case 0:
            item = commonItems[Random.Range(0, commonItems.Length)];
            break;

            case 1:
            item = uncommonItems[Random.Range(0, uncommonItems.Length)];
            break;

            case 2:
            item = rareItems[Random.Range(0, rareItems.Length)];
            break;

            case 3:
            item = epicItems[Random.Range(0, epicItems.Length)];
            break;

            case 4:
            item = legendaryItems[Random.Range(0, legendaryItems.Length)];
            break;
        }

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

                var Name = obj.transform.Find("ItemCount").GetComponent<Text>();
                
                Name.text = i.Value.ToString();

                var Icon = obj.transform.Find("ItemIcon").GetComponent<Image>();

                Icon.sprite = i.Key.itemIcon;
            }
        }
    }

    public void SwitchUI()
    {
        Globals.isUIOpen = !Globals.isUIOpen;
    }
}

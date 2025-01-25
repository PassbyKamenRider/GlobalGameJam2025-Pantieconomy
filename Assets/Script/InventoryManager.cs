using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

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
}

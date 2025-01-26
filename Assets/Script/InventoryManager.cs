using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;


public class InventoryManager : MonoBehaviour
{
    [SerializeField] Color[] rarityColors;
    [SerializeField] GameObject pantDisplayArea;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] MeshRenderer[] modelMaterial;
    [SerializeField] GameObject[] models;
    public static InventoryManager Instance;
    public Dictionary<Item, int> items = new();
    public Transform ItemContent;
    public GameObject InventoryItem;
    public Item[] commonItems, uncommonItems, rareItems, epicItems, legendaryItems;
    private int modelGender; // 0: female, 1: male

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (Item i in commonItems)
        {
            items[i] = 0;
        }
        foreach (Item i in uncommonItems)
        {
            items[i] = 0;
        }
        foreach (Item i in rareItems)
        {
            items[i] = 0;
        }
        foreach (Item i in epicItems)
        {
            items[i] = 0;
        }
        foreach (Item i in legendaryItems)
        {
            items[i] = 0;
        }
        ListItem();
    }

    private void Update()
    {
        if (Globals.enableTestMode)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Add Test Inventory");
                foreach (Item i in commonItems)
                {
                    AddItem(i);
                    AddItem(i);
                }
                foreach (Item i in uncommonItems)
                {
                    AddItem(i);
                }
                foreach (Item i in rareItems)
                {
                    AddItem(i);
                }
                foreach (Item i in epicItems)
                {
                    AddItem(i);
                }
                foreach (Item i in legendaryItems)
                {
                    AddItem(i);
                }
                ListItem();
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                SwitchModel();
            }
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

                obj.GetComponent<Image>().color = rarityColors[i.Key.itemRarity];

                obj.GetComponent<Button>().onClick.AddListener(() => DisplayItem(i.Key));

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

    public void DisplayItem(Item i)
    {
        if (!pantDisplayArea.activeSelf) pantDisplayArea.SetActive(true);

        descriptionText.text = i.itemDescription;
        modelMaterial[modelGender].material = i.materials[modelGender];
    }

    public void SwitchModel()
    {
        modelGender = Mathf.Abs(modelGender - 1);
        models[0].SetActive(false);
        models[1].SetActive(false);
        models[modelGender].SetActive(true);
    }
}

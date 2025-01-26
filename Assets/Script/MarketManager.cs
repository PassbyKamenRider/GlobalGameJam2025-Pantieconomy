using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public static MarketManager Instance;
    public Transform MarketContent;
    public GameObject marketItemPrefab;
    public Item[] commonItems, uncommonItems, rareItems, epicItems, legendaryItems;
    [SerializeField] GameObject pantDisplayArea;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] MeshRenderer[] modelMaterial;
    private int modelGender; // 0: female, 1: male
    private MarketItemDisplay selectedItem;

    [Header("Math")]

    public int MaxMarketCount;
    public int MarketItemCount;
    public float inflationModifierRange;
    public float inflationIndex;

    public float refreshRate;
    public int refreshTimeBeforeDecline;

    public float PriceOne;
    public float PriceTwo;
    public float PriceThree;
    public float PriceFour;
    public float PriceFive;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(MarketRefresh());
    }

    public void GenerateMarketItem(float inflation, float basePrice, int rarity) 
    {
        GameObject spawnedMarketItem = Instantiate(marketItemPrefab, MarketContent);
        MarketItemDisplay marketItemDisplay = spawnedMarketItem.GetComponent<MarketItemDisplay>();
        Item randItem = null;

        switch (rarity)
        {
            // common
            case 0:
            randItem = commonItems[Random.Range(0, commonItems.Length)];
            break;

            // uncommon
            case 1:
            randItem = uncommonItems[Random.Range(0, uncommonItems.Length)];
            break;

            // rare
            case 2:
            randItem = rareItems[Random.Range(0, rareItems.Length)];
            break;

            // epic
            case 3:
            randItem = epicItems[Random.Range(0, epicItems.Length)];
            break;

            // lengendary
            case 4:
            randItem = legendaryItems[Random.Range(0, legendaryItems.Length)];
            break;
        }

        marketItemDisplay.itemName = randItem.itemName;
        marketItemDisplay.itemIcon = randItem.itemIcon;
        marketItemDisplay.itemDescription = randItem.itemDescription;
        marketItemDisplay.itemMaterials = randItem.materials;

        //calculate price
        float modifier = Random.Range(-inflationModifierRange, inflationModifierRange);
        float inflatedPrice = basePrice * inflation + modifier;

        //calculate quantity
        int quantity = Random.Range(1, MarketItemCount);

        //change price
        marketItemDisplay.itemPrice = Mathf.Round(inflatedPrice * 100f) / 100f;

        //change quantity
        marketItemDisplay.itemQuantity = quantity;

        marketItemDisplay.UpdateDisplay();
    }

    public void GenerateNewMarket(float i)
    {
        foreach (Transform item in MarketContent)
        {
            if (item != null)
            {
                Destroy(item.gameObject);
            }
        }

        float ind = i / 5.0f;
        float inflation = 1.0f + ind * ind * ind;

        for (int j = 0; j < MaxMarketCount; j++)
        {
            int num = Random.Range(0, 100);

            if (num < 50)
            {
                GenerateMarketItem(inflation, PriceOne, 0);
            }

            else if (num < 80)
            {
                GenerateMarketItem(inflation, PriceTwo, 1);
            }
            else if (num < 90)
            {
                GenerateMarketItem(inflation, PriceThree, 2);
            }
            else if (num < 96)
            {
                GenerateMarketItem(inflation, PriceFour, 3);
            }
            else
            {
                GenerateMarketItem(inflation, PriceFive, 4);
            }
        }
    }

    private IEnumerator MarketRefresh()
    {
        float i = 0.01f;
        for(int j = 0; j <= refreshTimeBeforeDecline;j++) {
        
            GenerateNewMarket(i);
            i += 1.0f;

            yield return new WaitForSeconds(refreshRate);
        }

        for(int j = 0; j <= refreshTimeBeforeDecline; j++)
        {
            GenerateNewMarket(i);

            i -= 1.0f;

            yield return new WaitForSeconds(refreshRate);
        }
    }

    public void ChangeDescription(string text)
    {
        if (!pantDisplayArea.activeSelf) pantDisplayArea.SetActive(true);

        descriptionText.text = text;
    }

    public void ChangeModelMat(Material[] mat)
    {
        modelMaterial[modelGender].material = mat[modelGender];
    }

    public void SelectItem(MarketItemDisplay item)
    {
        selectedItem = item;
    }

    public void BuyItem()
    {
        if (selectedItem == null)
        {
            Debug.Log("No Item Selected!");
            return;
        }

        if (!PlayerStats.UseCash(selectedItem.itemPrice))
        {
            Debug.Log("Not Enough Money to Buy " + selectedItem.itemName);
        }
        else if (selectedItem.itemQuantity == 0)
        {
            Debug.Log("Item Is Sold Out!");
        }
        else
        {
            selectedItem.itemQuantity -= 1;
            selectedItem.UpdateDisplay();
            PlayerStats.UseCash(selectedItem.itemPrice);
            Debug.Log("Bought item " + selectedItem.itemName + " with price: " + selectedItem.itemPrice);
        }
    }
}

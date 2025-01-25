using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.CodeDom.Compiler;
using UnityEditor.ShaderGraph.Internal;

public class MarketManager : MonoBehaviour
{

    [SerializeField] public int GameTimeInSeconds;

    public static MarketManager Instance;

    public Transform MarketContent;

    public GameObject MarketContentPrefabOne;
    public GameObject MarketContentPrefabTwo;
    public GameObject MarketContentPrefabThree;
    public GameObject MarketContentPrefabFour;
    public GameObject MarketContentPrefabFive;

    private GameObject[] MarketContentOne;
    private GameObject[] MarketContentTwo;
    private GameObject[] MarketContentThree;
    private GameObject[] MarketContentFour;
    private GameObject[] MarketContentFive;



    [Header("Math")]

    public int MaxMarketCount;
    public int MarketItemCount;
    public float inflationModifierRange;
    public float inflationIndex;

    

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
        MarketContentOne = getChild(MarketContentPrefabOne);
        MarketContentTwo = getChild(MarketContentPrefabTwo);
        MarketContentThree = getChild(MarketContentPrefabThree);
        MarketContentFour = getChild(MarketContentPrefabFour);
        MarketContentFive = getChild(MarketContentPrefabFive);

        GenerateNewMarket(1.0f);
        

    }

    private void Update()
    {
        
    }

    public GameObject[] getChild(GameObject MarketItemCollectionLevel)
    {

        GameObject[] res = new GameObject[MarketItemCollectionLevel.transform.childCount];
        for (int i = 0; i < MarketItemCollectionLevel.transform.childCount; i++)
        {
            res[i] = MarketItemCollectionLevel.transform.GetChild(i).gameObject;
        }

        return res;
    
    }


    public void GenerateMarketItem(float inflation, float basePrice, GameObject[] Marketitems) 
    { 


        int i = Random.Range(0,Marketitems.Length);

        GameObject gameObject = Instantiate(Marketitems[i], MarketContent);

        //calculate price
        float modifier = Random.Range(-inflationModifierRange, inflationModifierRange);
        float inflatedPrice = basePrice * inflation + modifier;
        Debug.Log(inflatedPrice);

        //calculate quantity
        int num = Random.Range(1, MarketItemCount);

        //change price
        var price = gameObject.transform.Find("MarketItemPrice").GetComponent<Text>();   
        string priceStr = inflatedPrice.ToString("#.00");
        Debug.Log($"Price: {priceStr}");
        price.text = priceStr;
        Debug.Log(price.text);

        //change quantity
        var quantity = gameObject.transform.Find("MarketItemQuantity").GetComponent<Text>();
        string numStr = num.ToString();
        Debug.Log(numStr);
        quantity.text = numStr;
        Debug.Log(quantity.text);

    }

    public void GenerateNewMarket(float i)
    {
        float ind = i / 5.0f;
        float inflation = 1.0f + ind;

        for (int j = 0; j < MaxMarketCount; j++)
        {
            int num = Random.Range(0, 100);

            if (num < 50)
            {
                GenerateMarketItem(inflation, PriceOne, MarketContentOne);
            }

            else if (num < 80)
            {
                GenerateMarketItem(inflation, PriceTwo, MarketContentTwo);
            }
            else if (num < 90)
            {
                GenerateMarketItem(inflation, PriceThree, MarketContentThree);
            }
            else if (num < 96)
            {
                GenerateMarketItem(inflation, PriceFour, MarketContentFour);
            }
            else
            {
                GenerateMarketItem(inflation, PriceFive, MarketContentFive);
            }
        }
    }


}

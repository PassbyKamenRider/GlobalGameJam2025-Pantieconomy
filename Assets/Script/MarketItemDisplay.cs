using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketItemDisplay : MonoBehaviour
{
    [HideInInspector] public string itemName, itemDescription;
    [HideInInspector] public Sprite itemIcon;
    [HideInInspector] public float itemQuantity, itemPrice;
    [HideInInspector] public Material[] itemMaterials;
    [SerializeField] Image itemIconImg;
    [SerializeField] TextMeshProUGUI itemNameText, itemQuantityText, itemPriceText;
    [SerializeField] Button button;
    private MarketManager marketManager;

    private void Start()
    {
        marketManager = FindAnyObjectByType<MarketManager>();
        button.onClick.AddListener(DisplayItem);
    }

    public void UpdateDisplay()
    {
        itemNameText.text = itemName;
        itemIconImg.sprite = itemIcon;
        itemQuantityText.text = itemQuantity.ToString();
        itemPriceText.text = itemPrice.ToString();
    }

    private void DisplayItem()
    {
        marketManager.SelectItem(this);
        marketManager.ChangeDescription(itemDescription);
        marketManager.ChangeModelMat(itemMaterials);
    }
}
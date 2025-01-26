using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dropRateText, dropRarityText, popPerClickText;
    private float tempCost = 200;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }
    public void UpdateUpgradeDisplay()
    {
        dropRateText.text = "Current Drop Rate:\n" + PlayerStats.dropRate;
        dropRarityText.text = "Current Drop Rarity:\n" + PlayerStats.dropRarity;
        popPerClickText.text = "Current Bubble Popped Per Click:\n" + PlayerStats.popPerclick;
    }

    public void UpgradePlayer(int idx)
    {
        switch(idx)
        {
            // drop rate
            case 0:
            if (PlayerStats.UseCash(tempCost))
            {
                Debug.Log("Upgrade Drop Rate");
                soundManager.PlayPurchaseSound();
                PlayerStats.dropRate += 10f;
            }
            else
            {
                Debug.Log("Not Enough Money;");
            }
            break;

            // drop rarity
            case 1:
            if (PlayerStats.UseCash(tempCost))
            {
                Debug.Log("Upgrade Drop Rate");
                soundManager.PlayPurchaseSound();
                PlayerStats.dropRarity += 2.5f;
            }
            else
            {
                Debug.Log("Not Enough Money;");
            }
            break;

            // bubble popped per click
            case 2:
            if (PlayerStats.UseCash(tempCost))
            {
                Debug.Log("Upgrade Drop Rate");
                soundManager.PlayPurchaseSound();
                PlayerStats.popPerclick += 1;
            }
            else
            {
                Debug.Log("Not Enough Money;");
            }
            break;
        }

        UpdateUpgradeDisplay();
    }
}

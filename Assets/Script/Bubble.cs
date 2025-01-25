using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    [SerializeField] Sprite[] defaultBubbles, poppedBubbles;
    [SerializeField] SpriteRenderer defaultBubble, poppedBubble;
    public BubbleSheet bubbleSheet;
    private bool isPopped;

    private void Start()
    {
        int randIdx = Random.Range(0, defaultBubbles.Length);
        defaultBubble.sprite = defaultBubbles[randIdx];
        poppedBubble.sprite = poppedBubbles[randIdx];
    }

    private void OnMouseDown()
    {
        if (Globals.enableTestMode) PopBubble();
    }

    private void PopBubble()
    {
        if (!isPopped)
        {
            isPopped = true;
            defaultBubble.enabled = false;
            bubbleSheet.PopBubble();
            DetermineDrop();
        }
    }

    private void DetermineDrop()
    {
        float randVal = Random.Range(0f, 100f);

        Debug.Log("Drop rate determine value is: " + randVal);

        if (randVal <= PlayerStats.dropRate)
        {
            Debug.Log("Loot dropped, determine rarity");
            DetermineRarity();
        }
        else
        {
            Debug.Log("No loot dropped");
        }
    }

    private void DetermineRarity()
    {
        float randVal = Random.Range(0, 50f);
        float cumulativeRate = 0f;
        int rarity = 0;

        foreach (float droprate in Globals.dropRateTable)
        {
            cumulativeRate += droprate;

            if (randVal <= cumulativeRate)
            {
                // Chance to upgrade dropped loot
                if (Random.Range(0f, 100f) <= PlayerStats.dropRarity)
                {
                    Debug.Log("Loot is upgraded because of drop rarity!");
                    rarity += 1;
                }

                Debug.Log("Dropped item with rarity: " + Globals.rarityTable[rarity]);
                return;
            }

            rarity += 1;
        }

        Debug.Log("Failed to determine rarity");
    }
}

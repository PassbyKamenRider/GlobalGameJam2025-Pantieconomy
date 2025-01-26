using UnityEngine;

public class Globals : MonoBehaviour
{
    public static bool isUIOpen;
    public static int bubblePerSheet = 32;
    public static bool enableTestMode = true;
    public static float[] dropRateTable = {30f, 10f, 7.5f, 2f, 0.5f};
    public static string[] rarityTable = {"Common", "Uncommon", "Rare", "Epic", "Legendary"};
}

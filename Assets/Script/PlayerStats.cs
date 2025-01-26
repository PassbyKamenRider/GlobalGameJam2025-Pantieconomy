using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int poppedAmount;
    public static float dropRate = 50f;
    public static float dropRarity = 5f;
    public static int popPerclick = 1;
    public static float cash = 500f;

    public static void AddCash(float val)
    {
        cash += val;
    }

    public static bool UseCash(float val)
    {
        if (cash < val)
        {
            return false;
        }

        cash -= val;
        return true;
    }
}

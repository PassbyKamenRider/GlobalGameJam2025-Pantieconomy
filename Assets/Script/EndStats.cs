using UnityEngine;
using TMPro;

public class EndStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bubblePoppedText, pantCollectedText;

    private void Start()
    {
        bubblePoppedText.text = PlayerStats.poppedAmount.ToString();
        pantCollectedText.text = PlayerStats.pantCollected.ToString();
    }
}

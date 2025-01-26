using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource[] popSounds;
    [SerializeField] AudioSource[] purchaseSounds;
    public void PlayPopSound()
    {
        popSounds[Random.Range(0, popSounds.Length)].Play();
    }
    public void PlayPurchaseSound()
    {
        purchaseSounds[Random.Range(0, purchaseSounds.Length)].Play();
    }
}

using UnityEngine;

public class BubbleSheet : MonoBehaviour
{
    [SerializeField] Vector3 initPosition = new Vector3(-3.2f, 9.2f, 0f);
    [SerializeField] Vector3 initRotation = new Vector3(0f, 0f, -6f);
    [SerializeField] GameObject bubbleSheetPrefab;
    [SerializeField] Transform[] bubbleTransforms;
    [SerializeField] GameObject bubblePrefab;
    private Animator animator;
    private SoundManager soundManager;
    private int bubbleCount = Globals.bubblePerSheet;

    private void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
        animator = GetComponent<Animator>();
        for (int i = 0; i < bubbleTransforms.Length; i++)
        {
            GameObject spawnedBubble = Instantiate(bubblePrefab, bubbleTransforms[i].position, Quaternion.identity);
            spawnedBubble.transform.SetParent(transform);
            spawnedBubble.GetComponent<Bubble>().bubbleSheet = this;
        }
    }

    public void PopBubble()
    {
        soundManager.PlayPopSound();
        bubbleCount -= 1;
        if (bubbleCount == 0)
        {
            FadeOut();
        }
    }

    private void FadeOut()
    {
        Instantiate(bubbleSheetPrefab, initPosition, Quaternion.Euler(initRotation));
        animator.Play("BubbleSheetLeave");
    }

    public void DestorySelf()
    {
        Destroy(this.gameObject);
    }
}

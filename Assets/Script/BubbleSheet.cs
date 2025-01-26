using System.Collections.Generic;
using UnityEngine;

public class BubbleSheet : MonoBehaviour
{
    [SerializeField] Vector3 initPosition = new Vector3(-3.2f, 9.2f, 0f);
    [SerializeField] Vector3 initRotation = new Vector3(0f, 0f, -6f);
    [SerializeField] GameObject bubbleSheetPrefab;
    [SerializeField] Transform[] bubbleTransforms;
    [SerializeField] GameObject bubblePrefab;
    private List<Bubble> bubbles = new();
    private Animator animator;
    private SoundManager soundManager;
    private int bubbleCount = Globals.bubblePerSheet;
    private int idx;
    private bool hasEntered;

    private void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
        animator = GetComponent<Animator>();
        for (int i = 0; i < bubbleTransforms.Length; i++)
        {
            GameObject spawnedBubble = Instantiate(bubblePrefab, bubbleTransforms[i].position, Quaternion.identity);
            bubbles.Add(spawnedBubble.GetComponent<Bubble>());
            spawnedBubble.transform.SetParent(transform);
            spawnedBubble.GetComponent<Bubble>().bubbleSheet = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Globals.isUIOpen && hasEntered)
        {
            for (int i = 0; i < PlayerStats.popPerclick; i++)
            {
                if (idx >= bubbles.Count)
                {
                    Debug.Log("Out of bound, change sheet");
                    return;
                }

                bubbles[idx].PopBubble();
                idx++;
            }
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

    public void PlayDropSound()
    {
        soundManager.PlayGetSound();
    }

    private void FadeOut()
    {
        Instantiate(bubbleSheetPrefab, initPosition, Quaternion.Euler(initRotation));
        animator.Play("BubbleSheetLeave");
    }

    public void HasEnter()
    {
        hasEntered = true;
    }

    public void DestorySelf()
    {
        Destroy(this.gameObject);
    }
}

using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    public Item item;
    [SerializeField] public bool test;


    void Collect()
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && test)
        {
            Collect();
        }
    }
}


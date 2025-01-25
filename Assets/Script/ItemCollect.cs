using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    public Item item;

    void Collect()
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Globals.enableTestMode)
        {
            for (int i = 0; i < 100; i++)
            {
                Collect();
            }
        }
    }
}


using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class InventoryControl : MonoBehaviour
{

    [SerializeField] GameObject Inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ExitButton()
    {
        Inventory.SetActive(false);
    }
}

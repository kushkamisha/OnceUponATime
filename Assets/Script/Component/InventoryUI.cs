using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Canvas canvasObject;

    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        //inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        
        canvasObject = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
       if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        /*if (Input.GetKeyDown(KeyCode.O))
        {
            canvasObject.enabled = !canvasObject.enabled;
        }*/
        //inventory.SetActive(isShowing);
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } 
            else
            {
                slots[i].ClearSlor();
            }
        }
    }
}

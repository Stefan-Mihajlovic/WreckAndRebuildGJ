using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] InventoryUI inventoryUI;

    Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory();
        inventory.addItem(new Item("sword", 1));
        inventoryUI.SetInventory(inventory);
        inventoryUI.RefreshInventory();
    }
}

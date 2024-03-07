using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private List<Transform> itemSlots;

    private void Awake()
    {
        itemSlots = new List<Transform>();
        itemSlotContainer = transform;
        //puts all the slots in the list so that we have access to the slots
        for (int i = 0; i < itemSlotContainer.childCount; i++)
        {
            itemSlots.Add(itemSlotContainer.GetChild(i));
        }
    }

    public void SetInventory(Inventory inventory) 
    {
        this.inventory = inventory;
    }

    public void RefreshInventory() 
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i < inventory.itemCount)
            {
                itemSlots[i].Find("Item").gameObject.SetActive(true);
            }
            else
            {
                itemSlots[i].Find("Item").gameObject.SetActive(false);
            }
        }
    }
}

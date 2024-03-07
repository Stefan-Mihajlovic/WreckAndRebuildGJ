using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    public int itemCount;

    public Inventory() {
        itemList = new List<Item>();
        itemCount = itemList.Count;
    }

    public void addItem(Item item) {
        itemList.Add(item);
        itemCount = itemList.Count;
    }

    public List<Item> GetItems()
    {
        return itemList;
    }
}

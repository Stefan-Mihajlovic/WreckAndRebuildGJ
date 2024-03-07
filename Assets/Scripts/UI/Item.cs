using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName;
    public int amount;

    public Item(string name, int quantity) {
        itemName = name;
        amount = quantity;
    }
}

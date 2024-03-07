using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem
{
    //is also used as id
    public string itemName;
    //1 to 10
    public int speed;
    public int damage;
    //is only used without an aditional item
    public bool standalone;
    //false-head item, true-base item
    public bool isBase;

    public WeaponItem(string itemName, int speed, int damage, bool standalone, bool isBase)
    {
        this.itemName = itemName;
        this.speed = speed;
        this.damage = damage;
        this.standalone = standalone;
        this.itemName = itemName;
        this.isBase = isBase;
    }
    public WeaponItem(string itemName, int speed, int damage, bool standalone)
    {
        this.itemName = itemName;
        this.speed = speed;
        this.damage = damage;
        this.standalone = standalone;
        this.itemName = itemName;
        this.isBase = true;
    }
}

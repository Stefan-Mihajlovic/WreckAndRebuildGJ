using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Item", menuName ="Assets/WeaponItem")]
public class WeaponItem : ScriptableObject
{
    public string itemID;
    public string itemName;
    //1 to 10
    public int speed;
    public int damage;
    //is only used without an aditional item
    public bool standalone;
    //false-head item, true-base item
    public bool isBase;
    public Sprite sprite;

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

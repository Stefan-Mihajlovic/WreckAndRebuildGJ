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
    public bool isStandalone;
    //false-head item, true-base item
    public bool isBase;
    public Sprite sprite;
    public RuntimeAnimatorController animator;
}

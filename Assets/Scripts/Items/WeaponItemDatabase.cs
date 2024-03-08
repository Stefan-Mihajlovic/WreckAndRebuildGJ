using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Item Database", menuName = "Assets/WeaponItemDatabase")]
public class WeaponItemDatabase : ScriptableObject
{
    public List<WeaponItem> allItems;
}

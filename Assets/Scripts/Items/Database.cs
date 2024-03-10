using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public WeaponItemDatabase items;
    private List<WeaponItem> baseItems;
    private List<WeaponItem> headItems;

    private static Database instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
        baseItems = new List<WeaponItem>();
        headItems = new List<WeaponItem>();
        foreach (WeaponItem item in instance.items.allItems)
        {
            if (item.itemID != "none")
            {
                if (item.isBase == true)
                {
                    instance.baseItems.Add(item);
                }
                else
                {
                    instance.headItems.Add(item);
                }
            }
        }
    }
    public static WeaponItem GetItemByID(string itemID)
    {
        foreach (WeaponItem item in instance.items.allItems)
        {
            if (item.itemID == itemID)
            {
                return item;
            }
        }
        return null;
    }
    public static WeaponItem GetRandomItem()
    {
        return instance.items.allItems[Random.Range(1, instance.items.allItems.Count)];
    }
    public static WeaponItem GetRandomBaseItem()
    {
        return instance.baseItems[Random.Range(0, instance.baseItems.Count)];
    }
    public static WeaponItem GetRandomHeadItem()
    {
        return instance.headItems[Random.Range(0, instance.headItems.Count)];
    }
}

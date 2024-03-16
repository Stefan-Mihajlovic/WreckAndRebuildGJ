using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using System.Linq;

public class Database : MonoBehaviour
{
    public WeaponItemDatabase items;
    private List<WeaponItem> baseItems;
    private List<WeaponItem> headItems;

    public TaskDatabase tasks;
    public List<Task> currentTasks;

    [SerializeField]
    public List<TMP_Text> taskTextsUI;

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

        List<int> randNumbers = new List<int>();
        for (int i = 0; i < taskTextsUI.Count; i++)
        {
            while (true)
            {
                int rand = Random.Range(0, taskTextsUI.Count);
                if (!randNumbers.Contains(rand))
                {
                    randNumbers.Add(rand);
                    break;
                }
            }
        }

        for (int i = 0; i < taskTextsUI.Count; i++)
        {
            var task = GetRandomTask(randNumbers[i]);
            currentTasks.Add(task);
            taskTextsUI[i].text = task.taskDescription;
            taskTextsUI[i].GetComponentInChildren<Image>().sprite = task.taskItemToCollect.taskItemPrefab.GetComponent<SpriteRenderer>().sprite;
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

    public static Task GetRandomTask(int randomID)
    {
        return instance.tasks.allTasks[randomID];
    }
    public static List<Task> GetCurrentTasks()
    {
        return instance.currentTasks;
    }
    public static List<TMP_Text> getTaskUI()
    {
        return instance.taskTextsUI;
    }
}

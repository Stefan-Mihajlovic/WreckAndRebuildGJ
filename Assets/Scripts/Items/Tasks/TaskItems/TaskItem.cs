using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TaskItem_", menuName = "Assets/Task Item")]
public class TaskItem : ScriptableObject
{
    public string taskItemName;
    public string taskItemDescription;
    public bool isCompleted;
    public GameObject taskItemPrefab;
}

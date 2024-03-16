using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task_", menuName = "Assets/Task")]
public class Task : ScriptableObject
{
    public string taskTitle;
    public string taskDescription;

    public TaskItem taskItemToCollect;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task Database", menuName = "Assets/NewTaskDatabase")]
public class TaskDatabase : ScriptableObject
{
    public List<Task> allTasks;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTasks : MonoBehaviour
{
    private List<Task> currentTasks = new List<Task>();
    [SerializeField]
    private Sprite checkSprite;

    private void Start()
    {
        currentTasks = Database.GetCurrentTasks();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TaskItem")
        {
            string taskToRemoveDesc = "";
            foreach (var task in currentTasks)
            {
                if (task.taskItemToCollect.taskItemPrefab.name == collision.gameObject.name)
                {
                    task.isCompleted = true;
                    taskToRemoveDesc = task.taskDescription;
                    Destroy(collision.gameObject);
                }
            }
            foreach (var TMPText in Database.getTaskUI())
            {
                if (TMPText.text == taskToRemoveDesc)
                {
                    TMPText.GetComponentInChildren<Image>().sprite = checkSprite;
                    TMPText.color = Color.green;
                }
            }
            int br = 0;
            foreach (var task in currentTasks)
            {
                if (task.isCompleted)
                    br++;
            }
            if(br > 2)
            {
                Debug.Log("You collected everything, you filthy fuck");
            }
        }
    }
}

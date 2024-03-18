using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, boundsTilemap;
    public TileBase floorTile;
    public TileBase wallTile;
    public List<GameObject> itemsToSpawn;
    public List<GameObject> taskItemsToSpawn;
    public List<GameObject> enemiesToSpawn;
    private List<TaskItem> currentTasks;

    [SerializeField]
    private Transform player;

    public int minWidth = 5;
    public int maxWidth = 10;
    public int minHeight = 5;
    public int maxHeight = 10;

    private int startPosX;
    private int startPosY;

    void Start()
    {
        currentTasks = Database.GetCurrentTasks();
        foreach (TaskItem taskItem in currentTasks)
        {
            taskItemsToSpawn.Add(taskItem.taskItemPrefab);
        }
        GenerateRoom();
    }

    void GenerateRoom()
    {
        int width = Random.Range(minWidth, maxWidth + 1);
        int height = Random.Range(minHeight, maxHeight + 1);

        startPosX = -width;
        startPosY = -height;

        player.transform.position = new Vector3(startPosX + 3, startPosY + 3, 0);

        // Generate floor tiles
        for (int x = startPosX; x < width; x++)
        {
            for (int y = startPosY; y < height; y++)
            {
                floorTilemap.SetTile(new Vector3Int(x, y, 0), floorTile);
            }
        }

        // Generate walls
        for (int x = startPosX; x < width; x++)
        {
            boundsTilemap.SetTile(new Vector3Int(x, startPosY, 0), wallTile);
            boundsTilemap.SetTile(new Vector3Int(x, height - 1, 0), wallTile);
        }
        for (int y = startPosY; y < height; y++)
        {
            boundsTilemap.SetTile(new Vector3Int(startPosX, y, 0), wallTile);
            boundsTilemap.SetTile(new Vector3Int(width - 1, y, 0), wallTile);
        }

        // Place items randomly
        foreach (GameObject item in taskItemsToSpawn)
        {
                int randX = Random.Range(startPosX + 2, width - 2);
                int randY = Random.Range(startPosY + 2, height - 2);
                Instantiate(item, new Vector3(randX, randY, 0), Quaternion.identity);
        }
        foreach (GameObject item in itemsToSpawn)
        {
            for (int i = 0; i < 4; i++)
            {
                int randX = Random.Range(startPosX + 2, width - 2);
                int randY = Random.Range(startPosY + 2, height - 2);
                Instantiate(item, new Vector3(randX, randY, 0), Quaternion.identity);
            }
        }
        foreach (GameObject item in enemiesToSpawn)
        {
            int randomNumberOfEnemies = Random.Range(1, 10);
            for (int i = 0; i < randomNumberOfEnemies; i++)
            {
                int randX = Random.Range(startPosX + 2, width - 2);
                int randY = Random.Range(startPosY + 2, height - 2);
                Instantiate(item, new Vector3(randX, randY, 0), Quaternion.identity);
            }
        }
    }
}

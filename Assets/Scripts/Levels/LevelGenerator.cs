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
    public GameObject[] items;

    public int minWidth = 5;
    public int maxWidth = 10;
    public int minHeight = 5;
    public int maxHeight = 10;

    private int startPosX;
    private int startPosY;

    void Start()
    {
        GenerateRoom();
    }

    void GenerateRoom()
    {
        int width = Random.Range(minWidth, maxWidth + 1);
        int height = Random.Range(minHeight, maxHeight + 1);

        startPosX = -width;
        startPosY = -height;

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
        foreach (GameObject item in items)
        {
            int randX = Random.Range(startPosX + 1, width - 1);
            int randY = Random.Range(startPosY + 1, height - 1);
            Instantiate(item, new Vector3(randX, randY, 0), Quaternion.identity);
        }
    }
}

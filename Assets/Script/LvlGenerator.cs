using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{
    private Transform parent;

    public GameObject player;
    public GameObject enemy;
    public int enemyAmount = 10;

    public GameObject[] tiles;
    public GameObject wall;

    public List<Vector3> createdTiles;

    public int tileAmount;
    public int tileSize;

    public float waitTime;

    public float chanceUp;
    public float chanceRight;
    public float chanceLeft;

    // Wall generation
    private float minY = 99999999999;
    private float maxY = 0;
    private float minX = 99999999999;
    private float maxX = 0;

    public float xAmount;
    public float yAmount;
    public float extraWallX;
    public float extraWallY;

    void Start()
    {
        GenerateLevel();
        // Random.seed = 10;
    }

    void GenerateLevel()
    {
        initParentFolder();

        for (int i = 0; i < tileAmount; i++)
        {
            float direction = Random.Range(0f, 1f);
            int tile = Random.Range(0, tiles.Length);

            CreateTile(tile);
            CallMoveGen(direction);

            if (i == tileAmount - 1) Finish();
        }
    }

    void CallMoveGen(float ranDir)
    {
        if (ranDir < chanceUp)
            MoveGen(0);
        else if (ranDir < chanceRight)
            MoveGen(1);
        else if (ranDir < chanceLeft)
            MoveGen(2);
        else
            MoveGen(3);
    }

    void MoveGen(int direction)
    {
        switch(direction)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, transform.position.y + tileSize, 0);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, 0);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, 0);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, 0);
                break;
        }
    }

    void CreateTile(int tileIndex)
    {
        if (!createdTiles.Contains(transform.position))
        {
            GameObject tileObject;

            tileObject = Instantiate(tiles[tileIndex], transform.position, transform.rotation) as GameObject;
            createdTiles.Add(tileObject.transform.position);
            tileObject.transform.parent = parent;
        } else {
            ++tileAmount;
        }
    }

    void Finish()
    {
        CreateWallValues();
        CreateWalls();
        SpawnObjects();
    }

    void SpawnObjects()
    {
        Instantiate(player, createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);

        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(enemy, createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);
        }
    }

    void CreateWallValues()
    {
        // Find the min & max positions on x & y of generated floor to create walls
        for (int i = 0; i < createdTiles.Count; i++)
        {
            if (createdTiles[i].y < minY) minY = createdTiles[i].y;
            if (createdTiles[i].y > maxY) maxY = createdTiles[i].y;

            if (createdTiles[i].x < minX) minX = createdTiles[i].x;
            if (createdTiles[i].x > maxX) maxX = createdTiles[i].x;
        }

        xAmount = ((maxX - minX) / tileSize) + extraWallX * 2;
        yAmount = ((maxY - minY) / tileSize) + extraWallY * 2;
    }

    void CreateWalls()
    {
        for (int x = 0; x < xAmount; x++)
        {
            for (int y = (int)yAmount; y > 0; y--)
            {
                Vector3 wallPos = new Vector3(
                    (minX - extraWallX * tileSize) + (x * tileSize),
                    (minY - extraWallY * tileSize) + (y * tileSize));
                if (!createdTiles.Contains(wallPos))
                {
                    GameObject wallObj = (GameObject)Instantiate(wall, wallPos, transform.rotation);
                    wallObj.transform.parent = parent;
                }
            }
        }
    }

    void initParentFolder()
    {
        parent = new GameObject().transform;
        parent.name = "LvlParent";
    }
}

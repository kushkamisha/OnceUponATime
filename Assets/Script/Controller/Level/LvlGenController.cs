using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using amvcc;

public class LvlGenController : Controller<Application>
{
    // Wall generation
    private float minY = 99999999999;
    private float maxY = 0;
    private float minX = 99999999999;
    private float maxX = 0;

    private float waitTime = 0f;
    private float xAmount;
    private float yAmount;

    private List<float> extremeYPositions;
    private List<Vector3> wallPositions;

    // Generated blocks parent folder
    private Transform parent;

    public IEnumerator GenerateLevel()
    {
        initParentFolder();

        for (int i = 0; i < app.model.lvlgen.tileAmount; i++)
        {
            float direction = Random.Range(0f, 1f);
            int tile = Random.Range(0, app.model.lvlgen.tiles.Length);

            CreateTile(tile);
            CallMoveGen(direction);
        }

        yield return new WaitForSeconds(waitTime);
        Finish();
        yield return 0;
    }

    void CallMoveGen(float ranDir)
    {
        if (ranDir < app.model.lvlgen.chanceUp)
            MoveGen(0);
        else if (ranDir < app.model.lvlgen.chanceRight)
            MoveGen(1);
        else if (ranDir < app.model.lvlgen.chanceLeft)
            MoveGen(2);
        else
            MoveGen(3);
    }

    void MoveGen(int direction)
    {
        switch(direction)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, transform.position.y + app.model.lvlgen.tileSize, 0);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x + app.model.lvlgen.tileSize, transform.position.y, 0);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x, transform.position.y - app.model.lvlgen.tileSize, 0);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x - app.model.lvlgen.tileSize, transform.position.y, 0);
                break;
        }
    }

    void CreateTile(int tileIndex)
    {
        if (!app.model.lvlgen.createdTiles.Contains(transform.position))
        {
            GameObject tileObject;

            tileObject = Instantiate(app.model.lvlgen.tiles[tileIndex], transform.position, transform.rotation) as GameObject;
            app.model.lvlgen.createdTiles.Add(tileObject.transform.position);
            tileObject.transform.parent = parent;
        } else {
            ++app.model.lvlgen.tileAmount;
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
        // Spawn the player
        PlayerView player = Instantiate(app.model.lvlgen.player, app.model.lvlgen.createdTiles[Random.Range(0, app.model.lvlgen.createdTiles.Count)], Quaternion.identity);

        app.model.mainCamera.player = player;
        app.model.player.creatureRB = player.GetComponent<Rigidbody2D>();
        app.model.player.creatureAnim = player.GetComponent<Animator>();

        // Spawn Level door
        GameObject door = (GameObject)Resources.Load("Prefabs/Level Door", typeof(GameObject));
        door.transform.localScale = new Vector3(5, 5, 0);
        float yPos = extremeYPositions[Random.Range(0, extremeYPositions.Count)];
        List<Vector3> createdTilesLine = app.model.lvlgen.createdTiles.FindAll(pos => pos.y == yPos);
        Vector3 position = new Vector3(
            createdTilesLine[Random.Range(0, createdTilesLine.Count)].x,
            yPos + app.model.lvlgen.tileSize / 2,
            0
        );
        Instantiate(door, position, Quaternion.identity);

        // Spawn Enemies (Orcs)
        for (int i = 0; i < app.model.lvlgen.enemyAmount; i++)
        {
            EnemyView enemy = Instantiate(app.model.lvlgen.enemy, app.model.lvlgen.createdTiles[Random.Range(0, app.model.lvlgen.createdTiles.Count)], Quaternion.identity);
            app.model.enemy.creatureRB = enemy.GetComponent<Rigidbody2D>();
            app.model.enemy.creatureAnim = enemy.GetComponent<Animator>();
        }
    }

    void CreateWallValues()
    {
        // Find the min & max positions on x & y of generated floor to create walls
        for (int i = 0; i < app.model.lvlgen.createdTiles.Count; i++)
        {
            if (app.model.lvlgen.createdTiles[i].y < minY) minY = app.model.lvlgen.createdTiles[i].y;
            if (app.model.lvlgen.createdTiles[i].y > maxY) maxY = app.model.lvlgen.createdTiles[i].y;

            // extremeYPositions.Add(minY);
            extremeYPositions.Add(maxY);

            if (app.model.lvlgen.createdTiles[i].x < minX) minX = app.model.lvlgen.createdTiles[i].x;
            if (app.model.lvlgen.createdTiles[i].x > maxX) maxX = app.model.lvlgen.createdTiles[i].x;
        }

        xAmount = ((maxX - minX) / app.model.lvlgen.tileSize) + app.model.lvlgen.extraWallX * 2;
        yAmount = ((maxY - minY) / app.model.lvlgen.tileSize) + app.model.lvlgen.extraWallY * 2;
    }

    void CreateWalls()
    {
        for (int x = 0; x < xAmount; x++)
        {
            for (int y = (int)yAmount; y > 0; y--)
            {
                Vector3 wallPos = new Vector3(
                    (minX - app.model.lvlgen.extraWallX * app.model.lvlgen.tileSize) + (x * app.model.lvlgen.tileSize),
                    (minY - app.model.lvlgen.extraWallY * app.model.lvlgen.tileSize) + (y * app.model.lvlgen.tileSize));
                if (!app.model.lvlgen.createdTiles.Contains(wallPos))
                {
                    GameObject wallObj = (GameObject)Instantiate(app.model.lvlgen.wall, wallPos, transform.rotation);
                    wallObj.transform.parent = parent;
                }
            }
        }
    }

    void initParentFolder()
    {
        parent = new GameObject().transform;
        parent.name = "LvlParent";

        // Other
        extremeYPositions = new List<float>();
    }
}

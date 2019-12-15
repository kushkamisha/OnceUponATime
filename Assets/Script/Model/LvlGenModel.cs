using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using amvcc;

public class LvlGenModel : Model<Application>
{
    public PlayerView player;
    public EnemyView enemy;
    public int enemyAmount = 10;

    public GameObject[] tiles;
    public GameObject wall;

    public List<Vector3> createdTiles;

    public int tileAmount;
    public int tileSize = 16;

    public float chanceUp;
    public float chanceRight;
    public float chanceLeft;

    public float extraWallX;
    public float extraWallY;
}

﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using amvcc;

public class LvlGenModel : Model<Application>
{
    public PlayerView player;
    public List<EnemyView> enemies = new List<EnemyView>();
    public EnemyView enemy;
    public int defaultEnemyAmount = 3;
    public int enemyAmount = 3;

    public GameObject[] tiles;
    public GameObject wall;

    public List<Vector3> createdTiles;

    public GameObject coin;
    public int coinsToSpawn;
    public GameObject heart;
    public int heartsToSpawn;

    public int tileAmount;
    public int tileSize = 16;

    public float chanceUp;
    public float chanceRight;
    public float chanceLeft;

    public float extraWallX;
    public float extraWallY;
}

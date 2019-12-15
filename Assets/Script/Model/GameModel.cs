﻿using UnityEngine;
using System.Collections;
using amvcc;

// Contains all models related to the app
public class GameModel : Model<Application>
{
    // Reference to the Player model
    public PlayerModel player { get { return m_player = Assert<PlayerModel>(m_player); } }
    private PlayerModel m_player;

    public EnemyModel enemy { get { return m_enemy = Assert<EnemyModel>(m_enemy); } }
    private EnemyModel m_enemy;

    // Reference to the Camera model
    public CameraModel mainCamera { get { return m_mainCamera = Assert<CameraModel>(m_mainCamera); } }
    private CameraModel m_mainCamera;

    // Reference to the Level model
    public LevelModel level { get { return m_level = Assert<LevelModel>(m_level); } }
    private LevelModel m_level;

    // Reference to the Level Generator model
    public LvlGenModel lvlgen { get { return m_lvlgen = Assert<LvlGenModel>(m_lvlgen); } }
    private LvlGenModel m_lvlgen;
}
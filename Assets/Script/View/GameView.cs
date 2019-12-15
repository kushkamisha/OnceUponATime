using UnityEngine;
using System.Collections;
using amvcc;

// Contains all views related to the app
public class GameView : View<Application>
{
    // Reference to the Player view
    public PlayerView player { get { return m_player = Assert<PlayerView>(m_player); } }
    private PlayerView m_player;

    public EnemyView enemy { get { return m_enemy = Assert<EnemyView>(m_enemy); } }
    private EnemyView m_enemy;

    // Reference to the Camera view
    public CameraView mainCamera { get { return m_mainCamera = Assert<CameraView>(m_mainCamera); } }
    private CameraView m_mainCamera;

    // Reference to the Level view
    public LevelView level { get { return m_level = Assert<LevelView>(m_level); } }
    private LevelView m_level;

    // Reference to the Level Generator view
    public LvlGenView lvlgen { get { return m_lvlgen = Assert<LvlGenView>(m_lvlgen); } }
    private LvlGenView m_lvlgen;
}

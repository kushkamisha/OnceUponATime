using UnityEngine;
using System.Collections.Generic;
using amvcc;

// Contains all models related to the app
public class GameModel : Model<Application>
{
    // Reference to the Player model
    public PlayerModel player { get { return m_player = Assert<PlayerModel>(m_player); } }
    private PlayerModel m_player;

    public Orc1Model enemy { get { return m_enemy = Assert<Orc1Model>(m_enemy); } }
    private Orc1Model m_enemy;

    public List<Orc1Model> enemies = new List<Orc1Model>();
    public Orc1Model createOrc1Model()
    {
        this.enemies.Add(Instantiate(app.model.enemy));
        return this.enemies[this.enemies.Count-1];
    }

    // Reference to the Camera model
    public CameraModel mainCamera { get { return m_mainCamera = Assert<CameraModel>(m_mainCamera); } }
    private CameraModel m_mainCamera;

    // Reference to the Level model
    public LevelModel level { get { return m_level = Assert<LevelModel>(m_level); } }
    private LevelModel m_level;

    // Reference to the Level Generator model
    public LvlGenModel lvlgen { get { return m_lvlgen = Assert<LvlGenModel>(m_lvlgen); } }
    private LvlGenModel m_lvlgen;

    // Reference to the Level Generator model
    public LevelTextModel lvltext { get { return m_lvltext = Assert<LevelTextModel>(m_lvltext); } }
    private LevelTextModel m_lvltext;

    // Reference to the Pause model
    public PauseModel pause { get { return m_pause = Assert<PauseModel>(m_pause); } }
    private PauseModel m_pause;
}

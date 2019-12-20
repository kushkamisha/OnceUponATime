using UnityEngine;
using System.Collections;
using amvcc;

// Contains all controllers related to the app
public class GameController : Controller<Application>
{
    // Reference to the Player controller
    public PlayerController player { get { return m_player = Assert<PlayerController>(m_player); } }
    private PlayerController m_player;

    // Reference to the Enemy controller
    public EnemyController enemy { get { return m_enemy = Assert<EnemyController>(m_enemy); } }
    private EnemyController m_enemy;

    // Reference to the Camera controller
    public CameraController mainCamera { get { return m_mainCamera = Assert<CameraController>(m_mainCamera); } }
    private CameraController m_mainCamera;

    // Reference to the Level controller
    public LevelController level { get { return m_level = Assert<LevelController>(m_level); } }
    private LevelController m_level;

    // Reference to the Level Generator controller
    public LvlGenController lvlgen { get { return m_lvlgen = Assert<LvlGenController>(m_lvlgen); } }
    private LvlGenController m_lvlgen;

    // Reference to the Level Generator controller
    public LevelTextController lvltext { get { return m_lvltext = Assert<LevelTextController>(m_lvltext); } }
    private LevelTextController m_lvltext;

    public HealthBar healthBar { get { return m_healthBar = Assert<HealthBar>(m_healthBar); } }
    private HealthBar m_healthBar;

    public override void OnNotification(string p_event, Object p_target, params object[] p_data)
    {
        string type;

        switch (p_event)
        {
            case "player":
                type = (string)p_data[0];
                if (type == "move")
                    player.move();
                else if (type == "moveRB")
                    player.moveRB();
                else if (type == "kicking")
                    player.kickingPlayer();
                else if (type == "startPosHealth")
                {
                    // player.startPosHealth();
                    //Debug.Log("Start Pos Health");
                }
                /*else if (type == "decrease")
                    player.decreasingHP();*/
                break;

            case "enemy":
                type = (string)p_data[0];
                if (type == "action")
                    enemy.action(player.getCreature());
                if (type == "moveRB")
                    enemy.moveRB();
                break;

            case "camera":
                type = (string)p_data[0];
                if (type == "init")
                    mainCamera.init();
                else if (type == "move")
                    mainCamera.move();

                break;
            case "level door":

                Collider2D col = (Collider2D)p_data[0];
                level.loadScene(col);
                break;
            case "level":
                type = (string)p_data[0];
                if (type == "generate")
                    StartCoroutine(lvlgen.GenerateLevel());
                else if (type == "init")
                    level.Init();
                break;
            case "level.text":
                type = (string)p_data[0];
                if (type == "wait")
                    lvltext.SetText();
                    StartCoroutine(lvltext.RemoveTextAfterTime());
                break;
        }
    }
}

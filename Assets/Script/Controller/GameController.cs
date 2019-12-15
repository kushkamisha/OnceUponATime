﻿using UnityEngine;
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
                break;

            case "enemy":
                type = (string)p_data[0];
                if (type == "lookAround" & enemy.watchPlayer(player.getPosition()))
                    enemy.follow(player.getPosition());
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

        }
    }
}

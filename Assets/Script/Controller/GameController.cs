using UnityEngine;
using System.Collections;
using thelab.mvc;

// Contains all controllers related to the app
public class GameController : Controller<Application>
{
    // Reference to the Player controller
    public PlayerController player { get { return m_player = Assert<PlayerController>(m_player); } }
    private PlayerController m_player;

    public override void OnNotification(string p_event, Object p_target, params object[] p_data)
    {
        switch(p_event)
        {
            case "player.move":
                string type = (string)p_data[0];
                    if (type == "player") {
                        player.movePlayer();
                    } else if (type == "rb") {
                        player.moveRB();
                    }
                break;
        }
    }
}

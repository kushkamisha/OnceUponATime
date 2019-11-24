using UnityEngine;
using System.Collections;
using thelab.mvc;

// Contains all models related to the app
public class GameModel : Model<Application>
{
    // Reference to the Player model
    public PlayerModel player { get { return m_player = Assert<PlayerModel>(m_player); } }
    private PlayerModel m_player;
}

using UnityEngine;
using System.Collections;
using thelab.mvc;

// Contains all views related to the app
public class GameView : View<Application>
{
    // Reference to the Player view
    public PlayerView player { get { return m_player = Assert<PlayerView>(m_player); } }
    private PlayerView m_player;
}

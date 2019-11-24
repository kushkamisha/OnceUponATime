using UnityEngine;
using System.Collections;
using thelab.mvc;

public class PlayerView : View<Application>
{
    void Update()
    {
        Notify("player.move", "player");
    }

    void FixedUpdate()
    {
        Notify("player.move", "rb");
    }
}

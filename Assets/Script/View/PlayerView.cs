using UnityEngine;
using System.Collections;
using amvcc;

public class PlayerView : View<Application>
{
    void Start() 
    { 
        app.Notify("player.startPosHealth", app.controller, "startHealth");
    }

    void Update() { 
        app.Notify("player", app.controller, "move");
        app.Notify("player", app.controller, "kicking");
        app.Notify("player", app.controller, "startPosHealth");
        //app.Notify("player", app.controller, "decrease");
    }
    void FixedUpdate() { 
        Notify("player", "moveRB");
    }
}

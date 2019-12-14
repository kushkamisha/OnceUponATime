using UnityEngine;
using System.Collections;
using amvcc;

public class PlayerView : View<Application>
{
    void Update() { 
        app.Notify("player", app.controller, "move");
    }
    void FixedUpdate() { 
        Notify("player", "moveRB");
    }
}

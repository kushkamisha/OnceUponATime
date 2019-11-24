using UnityEngine;
using System.Collections;
using amvcc;

public class PlayerView : View<Application>
{
    void Update() { app.Notify("player.move", app.controller, "player"); }
    void FixedUpdate() { Notify("player.move", "rb"); }
}

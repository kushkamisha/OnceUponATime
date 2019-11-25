using UnityEngine;
using System.Collections;
using amvcc;

public class EnemyView : View<Application>
{
    void Update() { app.Notify("enemy.move", app.controller, "enemy"); }
    void FixedUpdate() { Notify("enemy.move", "rb"); }
}

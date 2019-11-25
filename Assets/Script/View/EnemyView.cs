using UnityEngine;
using System.Collections;
using amvcc;

public class EnemyView : View<Application>
{
    void Update() { 
        app.Notify("enemy.look_around", app.controller, "enemy");
    }
    void FixedUpdate() { Notify("enemy.look_around", "rb"); }
}

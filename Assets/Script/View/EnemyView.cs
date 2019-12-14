using UnityEngine;
using System.Collections;
using amvcc;

public class EnemyView : View<Application>
{
    void Update() { 
        app.Notify("enemy", app.controller, "lookAround");
    }
    void FixedUpdate() { 
        Notify("enemy", "moveRB");
    }
}

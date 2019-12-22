using UnityEngine;
using System.Collections;
using amvcc;

public class EnemyView : View<Application>
{
    void Update() { 
        app.Notify("enemy", app.controller, "action");
    }
    void FixedUpdate() { 
        Notify("enemy", "moveRB");
    }

    public void DecreaseHP(float val, GameObject obj) {
        Notify("enemy", "decreaseHP", val, obj);
    }
}

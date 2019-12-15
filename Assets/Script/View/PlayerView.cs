using UnityEngine;
using System.Collections;
using amvcc;

public class PlayerView : View<Application>
{
    public Texture imahe;

    void Start() 
    { 
        app.Notify("player.startPosHealth", app.controller, "startHealth");
    }

    void Update() { 
        app.Notify("player", app.controller, "move");
        app.Notify("player", app.controller, "kicking");
        app.Notify("player", app.controller, "decrHealth");
    }
    void FixedUpdate() { 
        Notify("player", "moveRB");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Enemy"))
            Debug.Log("Killed");
            // PlayerController.healthAmount -= 0.01f;
    }
}

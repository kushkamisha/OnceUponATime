using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using amvcc;

public class HeartScript : Controller<Application>
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (app.controller.player.getCreature().hp < 100) 
            {
                app.controller.player.getCreature().hp += 10f;
                Destroy(gameObject);
            }
        }
    }
}

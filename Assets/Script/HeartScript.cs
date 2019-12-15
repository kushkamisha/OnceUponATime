using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using amvcc;

public class HeartScript : Controller<Application>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            float value = app.controller.player.getHP();
            if (value < 0.12159f) 
            {
                Debug.Log("Hp increase");
                // PlayerController.healthAmount += 0.01f;
            }
            Destroy(gameObject);
        }
    }
}

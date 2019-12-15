using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using amvcc;

public class HealthBar : Controller<Application>
{
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = app.controller.player.getHP();
        transform.localScale = localScale;
    }
}

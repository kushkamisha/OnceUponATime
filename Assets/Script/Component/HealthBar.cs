using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using amvcc;

public class HealthBar : Controller<Application>
{

    private Constants constants = new Constants();
    public Vector3 localScale;
   
    void Start()
    {
        localScale = transform.localScale;
    }

    /*void Update()
    {
        localScale.x = app.controller.player.getCreature().hp / constants.hpCoef;
        transform.localScale = localScale;
    }*/
}

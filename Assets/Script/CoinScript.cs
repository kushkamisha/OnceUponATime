using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using amvcc;

public class CoinScript : Controller<Application>
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.coin_points++;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using amvcc;

public class SwordTrigger : Controller<Application>
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (gameObject.activeSelf)
            {
                // collision.gameObject.SetActive(false);
                EnemyView enemy = (EnemyView)collision.gameObject.GetComponent<EnemyView>();
                enemy.DecreaseHP(20f, collision.gameObject);
            }
        }
    }
}

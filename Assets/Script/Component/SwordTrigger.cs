using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using amvcc;

public class SwordTrigger : Controller<Application>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    // void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("sword trigger");
        if(collision.gameObject.tag == "Enemy")
        {
            //gameObject.GetComponent<Collider2D>().enabled = true;
            //Debug.Log("Enemy detected");
            if (gameObject.activeSelf)
            {
                Debug.Log("try to hit enemy");
                collision.gameObject.SetActive(false);
                EnemyView enemy = (EnemyView)collision.gameObject.GetComponent<EnemyView>();
                enemy.DecreaseHP(10f);
            }
        }
    }
}

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
    {
        Debug.Log("sword trigger");
        if(collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Enemy detected");
            if (gameObject.activeSelf)
            {
                collision.gameObject.SetActive(false);
                Destroy(GameObject.Find(collision.gameObject.name+"(Clone)"));
            }
        }
    }
}

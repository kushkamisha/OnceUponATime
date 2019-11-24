using UnityEngine;
using System.Collections;
using thelab.mvc;

public class PlayerController : Controller<Application>
{
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator anim;
    public float playerMoveSpeed = 5f;

    public override void OnNotification(string p_event, Object p_target, params object[] p_data)
    {
        switch(p_event)
        {
            case "player.move":
                string type = (string)p_data[0];
                    if (type == "player")
                        movePlayer();
                    else if (type == "rb")
                        moveRB();
                break;
        }
    }

    void movePlayer()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    void moveRB()
    {
        rb.MovePosition(rb.position + movement * playerMoveSpeed * Time.fixedDeltaTime);
    }
}

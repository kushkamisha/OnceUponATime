using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Element
{
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator anim;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * app.model.playerMoveSpeed * Time.fixedDeltaTime);
    }
}

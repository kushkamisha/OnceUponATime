using UnityEngine;
using System.Collections;
using amvcc;

public class PlayerController : Controller<Application>
{
    private Vector2 movement;
    
    public void movePlayer()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        app.model.player.playerAnim.SetFloat("Horizontal", movement.x);
        app.model.player.playerAnim.SetFloat("Vertical", movement.y);
        app.model.player.playerAnim.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void moveRB()
    {
        app.model.player.playerRB.MovePosition(app.model.player.playerRB.position + movement * app.model.player.playerMoveSpeed * Time.fixedDeltaTime);
    }
}

using UnityEngine;
using System.Collections;
using amvcc;

public class EnemyController : Controller<Application>
{
    private Vector2 movement;

    public void movePlayer(int x, int y)
    {
        movement.x = x;
        movement.y = y;

        app.model.enemy.playerAnim.SetFloat("Horizontal", movement.x);
        app.model.enemy.playerAnim.SetFloat("Vertical", movement.y);
        app.model.enemy.playerAnim.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void moveRB()
    {
        app.model.enemy.playerRB.MovePosition(app.model.enemy.playerRB.position + movement * app.model.enemy.playerMoveSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer(1, 1);
    }
}

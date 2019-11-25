using UnityEngine;
using System.Collections;
using amvcc;

public class EnemyController : Controller<Application>
{
    private Vector2 movement;

    public void movePlayer(float x, float y)
    {
        movement.x = x;
        movement.y = y;
        Vector3 coordinates = app.model.enemy.transform.position;
        app.model.enemy.transform.position = new Vector3(coordinates[0] + x, coordinates[1] + y, coordinates[2]);
        
        /*   app.model.enemy.enemyAnim.SetFloat("Horizontal", movement.x);
           app.model.enemy.enemyAnim.SetFloat("Vertical", movement.y);
           app.model.enemy.enemyAnim.SetFloat("Speed", movement.sqrMagnitude);*/
    }

    public void moveRB()
    {
        app.model.enemy.playerRB.MovePosition(app.model.enemy.playerRB.position + movement * app.model.enemy.playerMoveSpeed * Time.fixedDeltaTime);
    }
}

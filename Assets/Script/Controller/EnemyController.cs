using UnityEngine;
using System;
using System.Collections;
using amvcc;

public class EnemyController : Controller<Application>
{
    private Vector2 movement;

    public void moveEnemy(float x, float y)
    {
        movement.x = x;
        movement.y = y;
        Vector3 coordinates = app.model.enemy.enemyRB.position;
        app.model.enemy.enemyRB.position = new Vector3(coordinates[0] + x, coordinates[1] + y, coordinates[2]);

        /*app.model.enemy.enemyAnim.SetFloat("Horizontal", x);
        app.model.enemy.enemyAnim.SetFloat("Vertical", y);
        app.model.enemy.enemyAnim.SetFloat("Speed", movement.sqrMagnitude);*/
    }

    public void follow(float x, float y)
    {
        float x_direction = app.model.enemy.enemyMoveSpeed;
        float y_direction = app.model.enemy.enemyMoveSpeed;
        if (x - app.model.enemy.enemyRB.position[0] < 0)
            x_direction = -x_direction;
        if (y - app.model.enemy.enemyRB.position[1] < 0)
            y_direction = -y_direction;
        moveEnemy(x_direction, y_direction);

    }

    public void moveRB()
    {
        app.model.enemy.enemyRB.MovePosition(app.model.enemy.enemyRB.position + movement * app.model.enemy.enemyMoveSpeed * Time.fixedDeltaTime);
    }

    public bool watchPlayer(Vector3 player_coordinates)
    {
        Vector3 enemy_coordinates = app.model.enemy.enemyRB.position;
        if (Math.Pow(Math.Pow(enemy_coordinates[0] - player_coordinates[0], 2) + Math.Pow(enemy_coordinates[1] - player_coordinates[1], 2), 0.5) < app.model.enemy.RadiusOfVision)
        {
            return true;
;        }
        return false;
    }

}

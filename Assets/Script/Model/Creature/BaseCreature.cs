using UnityEngine;
using System;
using System.Collections;

public class BaseCreature
{
    public Vector2 movement;
    public Vector3 position;
    public float speed;
    public float ViewingRadius;

    public BaseCreature(Vector3 position)
    {
        this.movement = new Vector2(0, 0);
        this.position = position;
        this.speed = 5;
        this.ViewingRadius = 10;
    }

    public BaseCreature(Vector3 position, float speed, float ViewingRadius)
    {
        this.movement = new Vector2(0, 0);
        this.position = position;
        this.speed = speed;
        this.ViewingRadius = ViewingRadius;
    }

    public void move(float x, float y)
    {
        this.movement.x = x;
        this.movement.y = y;
        this.position = new Vector3(position[0] + this.movement.x, position[1] + this.movement.y, position[2]);
    }

    public void follow(float x, float y)
    {
        float x_direction = this.speed;
        float y_direction = this.speed;

        if (x - this.position[0] < 0)
            x_direction = -x_direction;
        if (y - this.position[1] < 0)
            y_direction = -y_direction;
        this.move(x_direction, y_direction);
    }

    public bool watchCreature(Vector3 creature_position)
    {
        if (Math.Pow(Math.Pow(this.position[0] - creature_position[0], 2) + Math.Pow(this.position[1] - creature_position[1], 2), 0.5) < this.ViewingRadius)
        {
            return true;
;        }
        return false;
    }



}

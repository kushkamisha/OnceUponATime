using UnityEngine;
using System;
using System.Collections;

public class BaseCreature
{
    public Vector3 movement;
    public Vector3 position;
    public virtual float speed { get; set; }
    public virtual float viewingRadius { get; set; }

    public BaseCreature(Vector3 position)
    {
        this.movement = new Vector3(0, 0, 0);
        this.position = position;
        this.speed = 2f;
        this.viewingRadius = 10f;
    }

    public BaseCreature(Vector3 position, float speed, float viewingRadius)
    {
        this.movement = new Vector3(0, 0, 0);
        this.position = position;
        this.speed = speed;
        this.viewingRadius = viewingRadius;
    }

    public void move(float x, float y)
    {
        this.movement.x = x;
        this.movement.y = y;
        this.position = this.position + this.movement * this.speed * Time.fixedDeltaTime;
    }

    public void follow(float x, float y)
    {
        float x_direction = this.speed;
        float y_direction = this.speed;  

        if (x - this.position.x < 0)
            x_direction = -x_direction;
        if (y - this.position.y < 0)
            y_direction = -y_direction;
        this.move(x_direction, y_direction);
    }

    public bool watchCreature(Vector3 creature_position)
    {
        if (Math.Pow(Math.Pow(this.position.x - creature_position.x, 2) + Math.Pow(this.position.y - creature_position.y, 2), 0.5) < this.viewingRadius)
        {
            return true;
;        }
        return false;
    }



}

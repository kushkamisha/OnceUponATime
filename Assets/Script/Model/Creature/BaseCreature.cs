using UnityEngine;
using System;

public class BaseCreature
{
    public Vector2 movement;
    public Vector2 position;
    public virtual float speed { get; set; }
    public virtual float viewingRadius { get; set; }
    public float hp { get; set; }

    public BaseCreature(Vector2 position)
    {
        this.movement = new Vector2(0, 0);
        this.hp = 100f;
        this.position = position;
        this.speed = 2f;
        this.viewingRadius = 10f;
    }

    public BaseCreature(Vector2 position, float hp, float speed, float viewingRadius)
    {
        this.movement = new Vector2(0, 0);
        this.hp = hp;
        this.position = position;
        this.speed = speed;
        this.viewingRadius = viewingRadius;
    }

    public void move(float x, float y)
    {
        this.movement.x = x;
        this.movement.y = y;
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
        return this.checkCloseToObject(creature_position, this.viewingRadius);
    }

    public bool checkCloseToObject(Vector3 creature_position, float radius)
    {
        if (Math.Pow(Math.Pow(this.position.x - creature_position.x, 2) + Math.Pow(this.position.y - creature_position.y, 2), 0.5) < radius)
        {
            return true;
            ;
        }
        return false;
    }

    public void decreaseHP(float value)
    {
        this.hp = this.hp - value;        
    }

}

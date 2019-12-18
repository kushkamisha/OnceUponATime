using UnityEngine;
using System;
using System.Collections;

public class PatrolCreature : CreatureAttack
{

    public string state = "patrol";
    public Vector3 patrolPoint;
    public float patrolRadius;
    private Vector2 patrolMovement = new Vector2(1, 1);

    public PatrolCreature(Vector3 position) : base(position)
    {
        this.patrolPoint = position;
        this.patrolRadius = 5f;
    }

    public PatrolCreature(Vector3 position,
        Vector3 patrolPoint,
        float patrolRadius,
        float viewingRadius,
        float speed,
        float defence,
        float force,
        int attackSpeed
        ) : base(position, viewingRadius, speed, defence, force, attackSpeed)
    {
        this.patrolPoint = patrolPoint;
        this.patrolRadius = patrolRadius;
    }

    private void patrol()
    {
        if (this.isFarFromPatrolPoint())
        {
            int[] directions = new int[2] { -1, 1 };
            System.Random random = new System.Random();
            this.patrolMovement = new Vector2(
                directions[random.Next(0, directions.Length)],
                directions[random.Next(0, directions.Length)]
                );
            this.follow(this.patrolPoint.x, this.patrolPoint.y);
        }
        else
        {
            this.move(this.patrolMovement.x, this.patrolMovement.y);
        }
        
    }

    private bool isFarFromPatrolPoint()
    {
        return !this.watchCreature(this.patrolPoint);
    }

    private bool canAttack()
    {
        /* Kill or just delete me please!!! */
        return false;
    }

    public void action(BaseCreature otherCreature)
    {
        switch (this.state)
        {
            case "patrol":
                if (this.watchCreature(otherCreature.position) & !this.isFarFromPatrolPoint()){
                    this.state = "following";
                }else
                {
                    this.patrol();
                }
                break;
            case "following":
                if (this.isFarFromPatrolPoint()){
                    this.state = "patrol";
                }
                else if (this.canAttack()){
                    this.state = "fight";
                }
                else if (this.watchCreature(otherCreature.position))
                {
                    this.follow(otherCreature.position.x, otherCreature.position.y);
                }
                else
                {
                    this.state = "patrol";
                }
                break;
            case "fight":
                if (!this.canAttack())
                {
                    this.state = "following";
                }
                else
                {
                    float damage = this.attack();
                    otherCreature.decreaseHP(damage);
                }
                break;

        }
    }
    public void action()
    {
        if (this.state == "patrol")
        {
            this.patrol();
        }
        else{
            if (this.isFarFromPatrolPoint())
            {
                this.follow(this.patrolPoint.x, this.patrolPoint.y);
            }
            else
            {
                this.state = "patrol";
            }
        }        
    }
}

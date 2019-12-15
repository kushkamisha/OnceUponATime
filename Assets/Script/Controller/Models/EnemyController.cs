using UnityEngine;
using System;
using amvcc;

public class EnemyController : Model<Application>
{
    private PatrolCreature creature;
    void Start()
    {
        this.creature = new PatrolCreature(
            app.model.enemy.creatureRB.position,
            app.model.enemy.creatureRB.position,
            app.model.enemy.patrolRadius,
            app.model.enemy.viewingRadius,
            app.model.enemy.speed,
            app.model.enemy.defence,
            app.model.enemy.force,
            app.model.enemy.attackSpeed
        );
    }

    public void move(float x, float y)
    {
        this.creature.move(x, y);

        /*app.model.enemy.creatureAnim.SetFloat("Horizontal", this.creature.movement.x);
        app.model.enemy.creatureAnim.SetFloat("Vertical", this.creature.movement.y);
        app.model.enemy.creatureAnim.SetFloat("Speed", this.creature.movement.sqrMagnitude);*/
    }

    public void moveRB()
    {
        app.model.enemy.creatureRB.MovePosition(this.creature.position);
    }

    public void action(BaseCreature otherCreature)
    {
        this.creature.action(otherCreature);
    }

    public Vector2 getPosition()
    {
        return this.creature.position;
    }

    public BaseCreature getCreature()
    {
        return this.creature;
    }

}

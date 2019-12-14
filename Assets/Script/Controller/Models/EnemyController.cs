using UnityEngine;
using System;
using amvcc;

public class EnemyController : Model<Application>
{
    private CreatureAttack creature;
    void Start()
    {
        this.creature = new CreatureAttack(
            app.model.enemy.creatureRB.position, 
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

    public bool watchPlayer(Vector3 creature_position)
    {
        return this.creature.watchCreature(creature_position);
    }

    public void follow(Vector2 creature_position)
    {
        this.creature.follow(creature_position.x, creature_position.y);
    }

}

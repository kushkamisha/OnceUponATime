using UnityEngine;
using System.Collections.Generic;
using amvcc;

public class EnemyController : Model<Application>
{
    private List<PatrolCreature> creatures = new List<PatrolCreature>();
    void Start()
    {
        
    }

    public void createEnemies()
    {
        for (int i = 0; i < app.model.enemies.Count; i++)
        {
            this.creatures.Add(new PatrolCreature(
                app.model.enemies[i].creatureRB.position,
                app.model.enemies[i].creatureRB.position,
                app.model.enemies[i].patrolRadius,
                app.model.enemies[i].viewingRadius,
                app.model.enemies[i].speed,
                app.model.enemies[i].defence,
                app.model.enemies[i].force,
                app.model.enemies[i].attackSpeed
            ));
        }
    }

    public void move(int enemyIndex, float x, float y)
    {
        this.creatures[enemyIndex].move(x, y);

        /*app.model.enemy.creatureAnim.SetFloat("Horizontal", this.creature.movement.x);
        app.model.enemy.creatureAnim.SetFloat("Vertical", this.creature.movement.y);
        app.model.enemy.creatureAnim.SetFloat("Speed", this.creature.movement.sqrMagnitude);*/
    }

    public void moveRB(int enemyIndex)
    {
        app.model.enemies[enemyIndex].creatureRB.MovePosition(this.creatures[enemyIndex].position);
    }

    public void moveRB()
    {
        for (int i = 0; i < this.creatures.Count; i++)
        {
            this.moveRB(i);
        }
    }

    public void action(int enemyIndex, BaseCreature otherCreature)
    {
        this.creatures[enemyIndex].action(otherCreature);
    }

    public void action(BaseCreature otherCreature)
    {
        for (int i = 0; i < this.creatures.Count; i++)
        {
            this.action(i, otherCreature);
        }
    }

    public Vector2 getPosition(int enemyIndex)
    {
        return this.creatures[enemyIndex].position;
    }

    public BaseCreature getCreature(int enemyIndex)
    {
        return this.creatures[enemyIndex];
    }

}

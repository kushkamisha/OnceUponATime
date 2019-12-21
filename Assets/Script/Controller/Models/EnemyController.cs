using UnityEngine;
using System.Collections.Generic;
using amvcc;

public class EnemyController : Model<Application>
{
    private List<PatrolCreature> creatures = new List<PatrolCreature>();

    public void createEnemies()
    {
        for (int i = 0; i < app.model.enemies.Count; i++)
        {
            this.creatures.Add(new PatrolCreature(
                app.model.enemies[i].creatureRB.position,
                app.model.enemies[i].circleSize,
                app.model.enemies[i].creatureRB.position,
                app.model.enemies[i].patrolRadius,
                app.model.enemies[i].viewingRadius,
                app.model.enemies[i].speed,
                app.model.enemies[i].defence,
                app.model.enemies[i].force,
                app.model.enemies[i].attackSpeed
            ));;
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
        app.model.enemies[enemyIndex].creatureRB.MovePosition(app.model.enemies[enemyIndex].creatureRB.position + this.creatures[enemyIndex].movement * this.creatures[enemyIndex].speed * Time.fixedDeltaTime);
        this.creatures[enemyIndex].position = app.model.enemies[enemyIndex].creatureRB.position;
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

    public void DecreaseHP(float val, GameObject obj)
    {
        app.model.enemy.hp -= val;
        // Destroy(GameObject.Find(collision.gameObject.name+"(Clone)"));
        Debug.Log("Enemy new HP: " + app.model.enemy.hp);

        // Debug.Log("HP width: " + app.view.player.transform.parent.GetChild(0).gameObject.transform.localScale);
        // Debug.Log(transform.Find("HP").gameObject.name);
        obj.transform.Find("HP").transform.localScale -= new Vector3((float)(3.45 / 6), 0, 0);
        // app.view.player.transform.localScale -= new Vector3(1, 0, 0);

        if (app.model.enemy.hp < 0) {
            Debug.Log("the enemy is dead");
            // Destroy(this);
            obj.SetActive(false);
        }
    }

}

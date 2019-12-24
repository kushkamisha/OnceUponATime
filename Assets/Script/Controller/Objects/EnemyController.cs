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
                app.model.enemies[i].hp,
                app.model.enemies[i].circleSize,
                app.model.enemies[i].creatureRB.position,
                app.model.enemies[i].patrolRadius,
                app.model.enemies[i].viewingRadius,
                app.model.enemies[i].speed,
                app.model.enemies[i].defence,
                app.model.enemies[i].force,
                app.model.enemies[i].attackSpeed,
                true
            ));
        }
    }

    public void move(int enemyIndex, float x, float y)
    {
        this.creatures[enemyIndex].move(x, y);
    }

    public void moveRB(int enemyIndex)
    {
        if (!this.creatures[enemyIndex].isActive) return;

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
        if (!this.creatures[enemyIndex].isActive) return;

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
        Orc1Model enemyModel = null;
        EnemyView enemyView = obj.GetComponent<EnemyView>();
        int index = 0;
    
        for (int i = 0; i < app.model.enemies.Count; i++)
            if (enemyView == app.model.enemies[i].view) {
                enemyModel = app.model.enemies[i];
                index = i;
            }

        enemyModel.hp -= val;

        if (enemyModel.hp <= 0) {
            Debug.Log("the enemy is dead");
            obj.SetActive(false);
            this.creatures[index].isActive = false;
        }

        // Shorten the HP bar
        float hpBarDefaultXScale = 3.45f;
        float hpBarDefaultYScale = 0.37f;
        obj.transform.Find("HP").transform.localScale = new Vector3((hpBarDefaultXScale * enemyModel.hp / 100), hpBarDefaultYScale, 0);
    }

}

using UnityEngine;
using System;
using System.Collections;
using amvcc;


public class CreatureAttack : BaseCreature { 

    private CreatureSkills skills;
    public override float speed { get => this.skills.speed; }
    public override  float viewingRadius { get => this.skills.viewingRadius; }

    private Constants constants = new Constants();
    private int attackCounter = 0;

    public CreatureAttack(Vector3 position) : base(position)
    {
        this.skills = new CreatureSkills();
    }

    public CreatureAttack(Vector3 position, float hp, float viewingRadius, float speed, float defence, float force, int attackSpeed): base(position, hp, speed, viewingRadius)
    {
        this.skills = new CreatureSkills(viewingRadius, speed, defence, force, attackSpeed);
    }

    public float giveDamage() {
        return this.skills.force * constants.damageCoef;
    }

    public void decreaseHP(float value){
        this.decreaseHP(value - this.skills.defence * constants.takeHitCoef);
    }

    public float attack()
    {
        float damage = -1f;
        if (this.attackCounter == 0)
        {
            damage = this.giveDamage();
            this.attackCounter = this.skills.attackSpeed;
        }
        else
        {
            this.attackCounter--;
        }

        return damage;

    }

    public void move(float x, float y)
    {
        base.move(x, y);
        if (this.attackCounter != 0)
        {
            this.attackCounter--;
        }
    }

}

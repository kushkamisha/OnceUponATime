using UnityEngine;
using System;
using System.Collections;
using amvcc;


public class CreatureAttack : BaseCreature { 

    private CreatureSkills skills;
    public override float speed { get => this.skills.speed; }
    public override  float viewingRadius { get => this.skills.viewingRadius; }


    public CreatureAttack(Vector3 position) : base(position)
    {
        this.skills = new CreatureSkills();
    }

    public CreatureAttack(Vector3 position, float viewingRadius, float speed, float defence, float force, float attackSpeed): base(position)
    {
        this.skills = new CreatureSkills(viewingRadius, speed, defence, force, attackSpeed);
    }

    /*public CreatureAttack(Vector3 position, float speed, float ViewingRadius, float v1, float v2) : base(position, speed, ViewingRadius)
    {
    }*/

    public float attack() {
        return this.skills.force;
    }

    public float defence() {
        return this.skills.defence;
    }

}

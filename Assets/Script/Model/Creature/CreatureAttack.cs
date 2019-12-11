using UnityEngine;
using System;
using System.Collections;
using amvcc;


public class CreatureAttack : BaseCreature { 

    private CreatureSkills skills;
    public float speed { get => this.skills.Speed; }
    public float ViewingRadius { get => this.skills.ViewingRadius; }


    public CreatureAttack(Vector3 position) : base(position)
    {
        this.skills = new CreatureSkills();
    }

    public CreatureAttack(Vector3 position, float ViewingRadius, float Speed, float Defence, float Force, float AttackSpeed): base(position)
    {
        this.skills = new CreatureSkills(ViewingRadius, Speed, Defence, Force, AttackSpeed);
    }

    public float attack() {
        return this.skills.Force;
    }

    public float defence() {
        return this.skills.Defence;
    }

}

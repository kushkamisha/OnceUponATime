using UnityEngine;
using System.Collections;

public class CreatureSkills: IWeapon
{
    private float defaultViewingRadius = 5f;
    private float defaultSpeed = 3f;
    private float defaultDefence = 0f;
    private float defaultForce = 0f;
    private int defaultAttackSpeed = 0;

    private IWeapon weapon = new Melee();


    public CreatureSkills(){}

    public CreatureSkills(float viewingRadius, float speed, float defence, float force, int attackSpeed) {
        if (viewingRadius <= 0 | speed <= 0 | defence < 0 | force < 0 | attackSpeed <= 0)
        {
            throw new System.Exception("The values can not be negative");
        }

        this.defaultViewingRadius = viewingRadius;
        this.defaultSpeed = speed;
        this.defaultDefence = defence;
        this.defaultForce = force;
        this.defaultAttackSpeed = attackSpeed;
    }

    public float viewingRadius { get => this.defaultViewingRadius + this.weapon.viewingRadius; }
    public float speed { get => this.defaultSpeed + this.weapon.speed; }
    public float defence { get => this.defaultDefence + this.weapon.defence; }
    public float force { get => this.defaultForce + this.weapon.force; }
    public int attackSpeed { get => this.defaultAttackSpeed + this.weapon.attackSpeed; }

    void setNewWeapon(IWeapon weapon)
    {
        this.weapon = weapon;
    }    
}

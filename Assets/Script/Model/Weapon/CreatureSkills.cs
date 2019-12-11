using UnityEngine;
using System.Collections;

public class CreatureSkills: IWeapon
{
    private float defaultViewingRadius = 5f;
    private float defaultSpeed = 3f;
    private float defaultDefence = 0f;
    private float defaultForce = 0f;
    private float defaultAttackSpeed = 0f;

    private IWeapon Weapon = new Melee();


    public CreatureSkills(){}

    public CreatureSkills(float ViewingRadius, float Speed, float Defence, float Force, float AttackSpeed) {
        if (ViewingRadius <= 0 | Speed <= 0 | Defence < 0 | Force < 0 | AttackSpeed <= 0)
        {
            throw new System.Exception("The values can not be negative");
        }

        this.defaultViewingRadius = ViewingRadius;
        this.defaultSpeed = Speed;
        this.defaultDefence = Defence;
        this.defaultForce = Force;
        this.defaultAttackSpeed = AttackSpeed;
    }

    public float ViewingRadius { get => this.defaultViewingRadius + this.Weapon.ViewingRadius; }
    public float Speed { get => this.defaultSpeed + this.Weapon.Speed; }
    public float Defence { get => this.defaultDefence + this.Weapon.Defence; }
    public float Force { get => this.defaultForce + this.Weapon.Force; }
    public float AttackSpeed { get => this.defaultAttackSpeed + this.Weapon.AttackSpeed; }

    void setNewWeapon(IWeapon Weapon)
    {
        this.Weapon = Weapon;
    }    
}

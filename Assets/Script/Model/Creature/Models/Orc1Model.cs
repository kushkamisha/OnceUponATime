using UnityEngine;
using amvcc;

public class Orc1Model : Model<Application>
{
    public Rigidbody2D creatureRB;
    public Animator creatureAnim;
    public float hp = 100f;
    public float speed = 3f;
    public float viewingRadius = 10f;
    public float force = 5f;
    public float defence = 3f;
    public float attackSpeed = 1f;
}


using UnityEngine;
using System.Collections;
using amvcc;

public class EnemyModel : Model<Application>
{
    public float enemyMoveSpeed = 4f;
    public Rigidbody2D enemyRB;
    public Animator enemyAnim;
    public float RadiusOfVision = 10f;
}
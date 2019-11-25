using UnityEngine;
using System.Collections;
using amvcc;

public class EnemyModel : Model<Application>
{
    public float playerMoveSpeed = 4f;
    public Rigidbody2D playerRB;
    public Animator enemyAnim;
}
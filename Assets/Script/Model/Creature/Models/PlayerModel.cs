using UnityEngine;
using amvcc;

public class PlayerModel : Model<Application>
{ 
    public Rigidbody2D playerRB;
    public Animator playerAnim;
    public float speed = 4f;
    public float viewingRadius = 10f;
    public float force = 1f;
    public float defence = 0f;
    public float attackSpeed = 1f;
}

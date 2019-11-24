using UnityEngine;
using System.Collections;
using amvcc;

public class PlayerModel : Model<Application>
{
    public float playerMoveSpeed = 5f;
    public Rigidbody2D playerRB;
    public Animator playerAnim;
}

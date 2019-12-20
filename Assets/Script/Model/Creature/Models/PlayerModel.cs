using UnityEngine;
using amvcc;

public class PlayerModel : Model<Application>
{ 
    public Rigidbody2D creatureRB;
    public Animator creatureAnim;
    public float hp = 100f;
    public float speed = 4f;
    public float viewingRadius = 10f;
    public float force = 1f;
    public float defence = 0f;
    public int attackSpeed = 50;
    public GameObject hpimg;
}

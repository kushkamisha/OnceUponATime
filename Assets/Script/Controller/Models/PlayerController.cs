using UnityEngine;
using amvcc;

public class PlayerController : Controller<Application>
{
    private CreatureAttack player;
    public static int coin_points = 0;

    private Vector2 mousePos;

    void Start(){
        this.player = new CreatureAttack(
            app.model.player.creatureRB.position, 
            app.model.player.viewingRadius, 
            app.model.player.speed,
            app.model.player.defence,
            app.model.player.force,
            app.model.player.attackSpeed
            );
    }

    public void move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        this.player.move(x, y);
        app.model.player.creatureAnim.SetFloat("Horizontal", this.player.movement.x);
        app.model.player.creatureAnim.SetFloat("Vertical", this.player.movement.y);
        app.model.player.creatureAnim.SetFloat("Speed", this.player.movement.sqrMagnitude);
    }

    public void moveRB()
    {
        app.model.player.creatureRB.MovePosition(this.player.position);
    }

    public Vector2 getPosition()
    {
        return this.player.position;
    }

    public BaseCreature getCreature()
    {
        return this.player;
    }

    public void kickingPlayer()
    {
        //app.model.player.kickPlayer = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.Space))
        {
            app.model.player.creatureAnim.SetBool("isKick", true);
            app.model.player.creatureAnim.SetBool("isNotKick", false);
        } else
        {
            app.model.player.creatureAnim.SetBool("isNotKick", true);
            app.model.player.creatureAnim.SetBool("isKick", false);
        }
        
        //app.model.player.playerAnim.SetBool("isKick", false);
    }

    public void decreaseHP()
    {
        if (this.player.hp <= 0)
            Destroy(gameObject);
    }

    public float getHP(){
        return this.player.hp;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Coins : " + coin_points);
        //GUI.Box(new Rect(10, 10, 50, 50), app.view.player.imahe, " " + coin_points);
    }
}

using UnityEngine;
using amvcc;

public class PlayerController : Controller<Application>
{
    private CreatureAttack player;
    void Start(){
        this.player = new CreatureAttack(
            app.model.player.playerRB.position, 
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
        app.model.player.playerAnim.SetFloat("Horizontal", this.player.movement.x);
        app.model.player.playerAnim.SetFloat("Vertical", this.player.movement.y);
        app.model.player.playerAnim.SetFloat("Speed", this.player.movement.sqrMagnitude);
    }

    public void moveRB()
    {
        app.model.player.playerRB.MovePosition(this.player.position);
    }
}

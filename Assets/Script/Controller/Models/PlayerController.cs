using UnityEngine;
using amvcc;

public class PlayerController : Controller<Application>
{

    private CreatureAttack player;
    void Start(){
        player = new CreatureAttack(app.model.player.playerRB.position);
    }

    public void move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Debug.Log(this.player.position);
        this.player.move(x, y);
    /*    app.model.player.playerRB.position = this.player.position;*/

        app.model.player.playerAnim.SetFloat("Horizontal", this.player.movement.x);
        app.model.player.playerAnim.SetFloat("Vertical", this.player.movement.y);
        app.model.player.playerAnim.SetFloat("Speed", this.player.movement.sqrMagnitude);
    }

    public void moveRB()
    {
        app.model.player.playerRB.MovePosition(app.model.player.playerRB.position + this.player.movement * this.player.speed * Time.fixedDeltaTime);
    }
}

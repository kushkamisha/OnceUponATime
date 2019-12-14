using UnityEngine;
using amvcc;

public class PlayerController : Controller<Application>
{
    private CreatureAttack player;
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
}

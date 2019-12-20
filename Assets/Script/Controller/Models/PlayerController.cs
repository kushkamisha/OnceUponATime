using UnityEngine;
using amvcc;

public class PlayerController : Controller<Application>
{
    private CreatureAttack player;
    public static int coin_points = 0;
    private Constants constants = new Constants();
    private string direction = "down";

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
        app.model.player.creatureRB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void move()
    {
        Debug.Log(this.player.hp);
 
        if (this.player.hp <= 0)
        {
            Destroy(gameObject);
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (app.model.player.creatureAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackRight")) return;
        if (app.model.player.creatureAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackLeft")) return;
        if (app.model.player.creatureAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackBack")) return;
        if (app.model.player.creatureAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackFront")) return;

        if (this.player.movement.x == 1) {
            direction = "right";
        } else if (this.player.movement.x == -1) {
            direction = "left";
        } else if (this.player.movement.y == 1) {
            direction = "up";
        } else if (this.player.movement.y == -1) {
            direction = "down";
        }

        if (this.player.movement.x == 0 && this.player.movement.y == 0) {
            switch(direction) {
                case "right":
                    app.model.player.creatureAnim.Play("IdleRight");
                    break;
                case "left":
                    app.model.player.creatureAnim.Play("IdleLeft");
                    break;
                case "up":
                    app.model.player.creatureAnim.Play("IdleBack");
                    break;
                case "down":
                    app.model.player.creatureAnim.Play("IdleFront");
                    break;  
            }
        }

        this.player.move(x, y);

        app.model.player.creatureAnim.SetFloat("Horizontal", this.player.movement.x);
        app.model.player.creatureAnim.SetFloat("Vertical", this.player.movement.y);
        app.model.player.creatureAnim.SetFloat("Speed", this.player.movement.sqrMagnitude);
    }

    public void moveRB()
    {
        app.model.player.creatureRB.MovePosition(app.model.player.creatureRB.position + this.player.movement * this.player.speed * Time.fixedDeltaTime);
        this.player.position = app.model.player.creatureRB.position;
    }

    public Vector2 getPosition() { return this.player.position; }

    public BaseCreature getCreature() { return this.player; }

    /*public void decreasingHP()
    {
<<<<<<< HEAD
        //app.controller.healthBar.transform.localScale = app.controller.healthBar.localScale;
        Debug.Log("WHYYYY");
        if (player.hp < 100)
        {
            Debug.Log("YESSSS");
            app.controller.healthBar.localScale.x = player.hp / constants.hpCoef;
            app.controller.healthBar.transform.localScale = new Vector3(app.controller.healthBar.localScale.x,0.01048f,0.39110f);
        }
    }*/
=======
        Debug.Log("SS");
        app.controller.healthBar.localScale.x = player.hp / constants.hpCoef;
        app.controller.healthBar.transform.localScale = app.controller.healthBar.localScale;
    }
>>>>>>> attack

    public void kickingPlayer() {
        if (Input.GetKey(KeyCode.Space) && this.player.movement.x == 0 && this.player.movement.y == 0)
        {
            switch(direction) {
                case "right":
                    app.model.player.creatureAnim.Play("AttackRight");
                    break;
                case "left":
                    app.model.player.creatureAnim.Play("AttackLeft");
                    break;
                case "up":
                    app.model.player.creatureAnim.Play("AttackBack");
                    break;
                case "down":
                    app.model.player.creatureAnim.Play("AttackFront");
                    break;  
            }
        }
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();

        // Load and set Font
        Font myFont = (Font)Resources.Load("Fonts/ThaleahFat_TTF", typeof(Font));
        style.font = myFont;
        style.fontSize = 80;

        // Set color for selected and unselected buttons
        style.normal.textColor = Color.yellow;
        // myButtonStyle.hover.textColor = Color.red;

        GUI.Label(new Rect(40, 10, 100, 20), "Coins : " + coin_points, style);
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Enemy"))
        {
            app.model.enemy.hp -= 10f;
            Debug.Log("Enemy HP: " + app.model.enemy.hp);
        }
    }*/
}

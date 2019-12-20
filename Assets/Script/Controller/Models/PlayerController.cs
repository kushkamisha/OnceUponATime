using UnityEngine;
using amvcc;

public class PlayerController : Controller<Application>
{
    private CreatureAttack player;
    public static int coin_points = 0;
    private Constants constants = new Constants();

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

    public Vector2 getPosition()
    {
        return this.player.position;
    }

    public BaseCreature getCreature()
    {
        return this.player;
    }

    /*public void decreasingHP()
    {
        //app.controller.healthBar.transform.localScale = app.controller.healthBar.localScale;
        Debug.Log("WHYYYY");
        if (player.hp < 100)
        {
            Debug.Log("YESSSS");
            app.controller.healthBar.localScale.x = player.hp / constants.hpCoef;
            app.controller.healthBar.transform.localScale = new Vector3(app.controller.healthBar.localScale.x,0.01048f,0.39110f);
        }
    }*/

    public void kickingPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            app.model.player.creatureAnim.SetBool("attack", true);
            app.model.player.creatureAnim.SetBool("nattack", false);
        }
        else
        {
            app.model.player.creatureAnim.SetBool("attack", false);
            app.model.player.creatureAnim.SetBool("nattack", true);
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Enemy"))
        {
            app.model.enemy.hp -= 10f;
            Debug.Log("Enemy HP: " + app.model.enemy.hp);
        }
    }
}

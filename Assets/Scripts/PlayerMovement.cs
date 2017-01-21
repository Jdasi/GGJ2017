using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnimator;

    public float climb_speed = 0;
    public float move_speed = 5.0f;
    public float drag_speed = 5.0f;
    public float jump_force = 300.0f;
    public float air_control = 0.25f;

    public bool on_ladder = false;
    public bool on_ice = false;

    private BoxCollider2D box_collider;
    private Rigidbody2D rigid_body;
    private JumpCheck jump_check;

    private float climb_velocity = 0;
    private float gravity_store = 0;

    void Start () 
    {
        box_collider = GetComponent<BoxCollider2D>();
	    rigid_body = GetComponent<Rigidbody2D>();
        jump_check = GetComponentInChildren<JumpCheck>();

        gravity_store = rigid_body.gravityScale;
    }
    
	void Update()
    {
        jump();
        move();
	}

    void move()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //set animation speed
        playerAnimator.SetFloat("Speed", Mathf.Abs(input.x));

        //flip animation root direction
        if (input.x > 0)
        {
            playerAnimator.transform.localScale = new Vector2(0.5f, playerAnimator.transform.localScale.y);
        }
        if (input.x < 0)
        {
            playerAnimator.transform.localScale = new Vector2(-0.5f, playerAnimator.transform.localScale.y);
        }

        if (jump_check.can_jump)
        {
            playerAnimator.SetBool("IsAirborn", false);
            rigid_body.AddForce(new Vector2(input.x * move_speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        else
        {
            playerAnimator.SetBool("IsAirborn", true);
            rigid_body.AddForce(new Vector2(input.x * (move_speed * air_control) * Time.deltaTime, 0), ForceMode2D.Impulse);
        }

        if (input.x == 0 && jump_check.can_jump)
		{
            rigid_body.velocity = new Vector2(Mathf.Lerp(rigid_body.velocity.x, 0, drag_speed * Time.deltaTime), rigid_body.velocity.y);
        }

        //Ladder movement
        if(on_ladder)
        {
            rigid_body.gravityScale = 0;
            climb_velocity = climb_speed * Input.GetAxisRaw("Vertical");
            rigid_body.velocity = new Vector2(rigid_body.velocity.x, climb_velocity);
            
        }
        if (!on_ladder)
        {
            rigid_body.gravityScale = gravity_store;
        }

        if(on_ice)
        {
            drag_speed = 0;
        } else if (!on_ice)
        {
            drag_speed = 5.0f;
        }
    }

    void jump()
    {
        if (Input.GetButtonDown("Jump") && jump_check.can_jump)
        {
            rigid_body.AddForce(new Vector2(0, jump_force));
        }
    }
}

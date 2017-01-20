using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float climb_speed = 0;
    public float move_speed = 5.0f;
    public float drag_speed = 5.0f;
    public float jump_force = 300.0f;
    public float air_control = 0.25f;

    public LayerMask collision_mask;

    public bool on_ladder = false;

    private BoxCollider2D box_collider;
    private Rigidbody2D rigid_body;

    private bool can_jump = true;
    private float climb_velocity = 0;
    private float gravity_store = 0;
    void Start () 
    {
        box_collider = GetComponent<BoxCollider2D>();
	    rigid_body = GetComponent<Rigidbody2D>();
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

        if (can_jump)
            rigid_body.AddForce(new Vector2(input.x * move_speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        else
            rigid_body.AddForce(new Vector2(input.x * (move_speed * air_control) * Time.deltaTime, 0), ForceMode2D.Impulse);

        if (input.x == 0)
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
    }

    void jump()
    {
        Bounds bounds = box_collider.bounds;
        Vector2 ray_origin = new Vector2((bounds.min.x + bounds.max.x) / 2, bounds.min.y);

        RaycastHit2D hit = Physics2D.Raycast(ray_origin, Vector2.up, -int.MaxValue, collision_mask);
        can_jump = hit.distance < 0.1f;

        Debug.DrawRay(ray_origin, Vector2.up * -int.MaxValue, Color.red);

        if (Input.GetButtonDown("Jump") && can_jump)
        {
            rigid_body.AddForce(new Vector2(0, jump_force));
        }
    }
}

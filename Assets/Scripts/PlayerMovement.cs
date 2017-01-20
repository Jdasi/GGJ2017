using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0f;
    public string axisName = "Horizontal";
    public string yAxis = "Vertical";

    public Animator anim;
    public bool OnGround;
    public bool onLadder = false;
    void Start () 
    {
        anim = gameObject.GetComponent<Animator> ();
    }

    void Update()
    {  

    }

    void OnCollisionStay2D(Collision2D coll)
    {
       
        OnGround = true;
        if (OnGround == true)
        {
            if (Input.GetKeyDown (KeyCode.Space)) 
            {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 5), ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Ladder")
        {
            onLadder = true;
        }    
        else
        {
            onLadder = false;

        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (OnGround) 
        {
            OnGround = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate () 
    {
        transform.position += transform.right * Input.GetAxis(axisName) * speed * Time.deltaTime;

        if(onLadder)
        {
            transform.position += transform.up * Input.GetAxis(yAxis);
        }
    }

}

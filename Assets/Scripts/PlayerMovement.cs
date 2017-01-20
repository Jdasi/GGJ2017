using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 20.0f;
    public string axisName = "Horizontal";
    public Animator anim;
    public bool OnGround;

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
    }
}

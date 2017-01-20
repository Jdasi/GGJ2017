using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
    public int speed = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col)
    {

       // Physics2D.gravity = new Vector2(0,0);
        if(col.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else if (col.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}

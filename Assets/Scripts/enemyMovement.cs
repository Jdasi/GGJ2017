using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

    // Use this for initialization

    private bool moveLeft;
    private float speed;
    private int moveChance;
    private bool checkMove;



	void Start ()
    {
        moveLeft = true;
        checkMove = true;
        speed = 1;
        

        InvokeRepeating("checkMoveChance", 1.0f, Random.Range(2.0f, 5.0f));

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if (moveLeft && checkMove)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if(!moveLeft && checkMove)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Platform")
        {
            moveLeft = !moveLeft;
        }
    }


    void checkMoveChance()
    {
        moveChance = Random.Range(1, 100);

        if(moveChance >= 1 && moveChance <= 30)
        {
            checkMove = false;
        }
        else
        {
            checkMove = true; 
        }
    }

}

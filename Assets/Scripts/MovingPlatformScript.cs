using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {

    bool moveDirection = true;
    bool isFrozen = false;
    public int speed = 1;
    public float maxDistanceRight = 0;
    public float maxDistanceLeft = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        checkTemp();

        if (checkFrozen() != true)
        {
            movePlatform();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        changeDirection();
    }

    void changeDirection()
    {
        if (moveDirection)
        {
            moveDirection = false;
        }

        else
        {
            moveDirection = true;
        }
    }

    void movePlatform()
    {
        if (moveDirection)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        checkDistance();
    }

    bool checkFrozen()
    {
        if (isFrozen)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    void checkTemp()
    {
        GameObject background = GameObject.Find("scrollingBackground");
        if (background.GetComponent<BackgroundColour>().isCold)
        {
            isFrozen = true;
            //set sprite to frozen;   
        }

        else if (background.GetComponent<BackgroundColour>().isCold != true)
        {
            isFrozen = false;
            //set sprite to normal;
        }
    }

    void checkDistance()
    {
        if (transform.position.x > maxDistanceRight)
        {
            changeDirection();
        }

        else if (transform.position.x > maxDistanceLeft)
        {
            changeDirection();
        }
    }
}

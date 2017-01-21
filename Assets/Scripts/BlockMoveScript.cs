using UnityEngine;
using System.Collections;

public class BlockMoveScript : MonoBehaviour {

    bool moveDirection = true;
    bool isFrozen = false;
    public int speed = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        checkTemp();

        if (checkFrozen() != true)
        {
            checkDirection();
            moveBlock();
        }      
    }

    void checkDirection()
    {
        if (transform.position.y > 1.5)
        {
            moveDirection = true;
        }

        else if (transform.position.y < -1)
        {
            moveDirection = false;
        }
    }

    void moveBlock()
    {
        if (moveDirection)
        {
            transform.position += Vector3.down * 10 * Time.deltaTime;
        }

        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
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
}

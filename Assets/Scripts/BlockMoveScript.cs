using UnityEngine;
using System.Collections;

public class BlockMoveScript : MonoBehaviour {

    bool moveDirection = true;
    bool isFrozen = false;
    public int speed = 0;
    public float maxHeight = 1.5f;
    public float minHeight = -1;

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
        if (transform.position.y > maxHeight)
        {
            moveDirection = true;
        }

        else if (transform.position.y < minHeight)
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
        GameObject background = GameObject.Find("Winter");
        if (background.GetComponent<WinterBackground>().isCold)
        {
            isFrozen = true;
            //set sprite to frozen;   
        }

        else if (background.GetComponent<WinterBackground>().isCold != true)
        {
            isFrozen = false;
            //set sprite to normal;
        }
    }
}

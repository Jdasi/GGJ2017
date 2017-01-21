using UnityEngine;
using System.Collections;

public class BlockMoveScript : MonoBehaviour {

    bool moveDirection = true;
    bool isFrozen = true;
    public int speed = -2;
    public float maxHeight = 1.5f;
    public float minHeight = -1;
    private WorldState world_state;

    // Use this for initialization
    void Start () {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

       // checkTemp();

        if (isFrozen != true)
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
        if (!world_state.is_hot)
        {
            isFrozen = true;
            //change sprite
        }

        else
        {
            isFrozen = false;
            //change sprite
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeatWaveSource")
        {
            checkTemp();
        }
    }
}

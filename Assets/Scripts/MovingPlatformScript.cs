using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {

    bool moveDirection = true;
    bool isFrozen = true;
    public int speed = 1;
    public float maxDistanceRight = 0;
    public float maxDistanceLeft = 0;
    private WorldState world_state;

    // Use this for initialization
    void Start () {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();

        world_state.kinda_heatwave_objects.Add(gameObject);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isFrozen != true)
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

    void checkDistance()
    {
        if (transform.position.x > maxDistanceRight)
        {
            changeDirection();
        }

        else if (transform.position.x < maxDistanceLeft)
        {
            changeDirection();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeatWaveSource")
        {
            checkTemp();
        }
    }

    public void react()
    {
        checkTemp();
    }
}

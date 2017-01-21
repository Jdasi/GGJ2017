using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

    // Use this for initialization

    private bool moveLeft;
    public float speed;
    private int moveChance;
    private bool checkMove;
    private bool triggered;
    //private bool isFrozen;

    public Sprite normalSprite;
    public Sprite frozenSprite;

    private WorldState world_state;

    void Start ()
    {
        moveLeft = true;
        checkMove = true;
        speed = 3;   
        InvokeRepeating("checkMoveChance", 1.0f, Random.Range(2.0f, 5.0f));
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
        setFrozen();
    }

    // Update is called once per frame
    void Update ()
    {
            if (moveLeft && checkMove)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else if (!moveLeft && checkMove)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Tile")
        {
            moveLeft = !moveLeft;
        }
        if (coll.tag == "HeatWaveSource")
        {
            setFrozen();
        }
    }


    void checkMoveChance()
    {
        if(world_state.is_hot)
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


    void setFrozen()
    {
        if(!world_state.is_hot)
        {
            checkMove = false;
            GetComponent<SpriteRenderer>().sprite = frozenSprite;
        }
        else if(world_state.is_hot)
        {
            checkMove = true;
            GetComponent<SpriteRenderer>().sprite = normalSprite;
        }

    }

}

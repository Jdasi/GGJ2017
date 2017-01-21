using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

    // Use this for initialization

    private bool moveLeft;
    public float speed;
    private int moveChance;
    private bool checkMove;
    private bool isFrozen;

    public Sprite normalSprite;
    public Sprite frozenSprite;

	void Start ()
    {
        moveLeft = true;
        checkMove = true;
        isFrozen = false;
        speed = 3;   
        InvokeRepeating("checkMoveChance", 1.0f, Random.Range(2.0f, 5.0f));

	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (moveLeft && checkMove)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if(!moveLeft && checkMove)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }


        if(Input.GetKeyDown(KeyCode.E))
        {
            setFrozen();
        }

	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Obstacle")
        {
            moveLeft = !moveLeft;
        }
    }


    void checkMoveChance()
    {
        if(!isFrozen)
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
        isFrozen = !isFrozen;

        if(isFrozen)
        {
            checkMove = false;
            GetComponent<SpriteRenderer>().sprite = frozenSprite;
        }
        else
        {
            checkMove = true;
            GetComponent<SpriteRenderer>().sprite = normalSprite;
        }

    }

}

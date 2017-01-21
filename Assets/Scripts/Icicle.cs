using UnityEngine;
using System.Collections;

public class Icicle : MonoBehaviour {
    public GameObject[] icicles;

    public bool triggered = false;

    private int i = 0;
<<<<<<< HEAD
    private int fallChance;

//<<<<<<< HEAD

//=======
    private Rigidbody2D[] rigid_body;
//>>>>>>> origin/master
=======

    private Rigidbody2D[] rigid_body;
>>>>>>> origin/master

    void Start () 
    {
        InvokeRepeating("checkFallChance", 0.5f, Random.Range(1f, 2.0f));

        for (int i = 0; i < icicles.Length; i++)
        {
            rigid_body[i] = icicles[i].GetComponent<Rigidbody2D>();
            rigid_body[i].gravityScale = 0;
        }
    }

    // Update is called once per frame
    void Update ()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            triggered = true;   
        }
    }

    void moveIcicle(int i)
    {
<<<<<<< HEAD
//<<<<<<< HEAD

        //crushPosition.x = (icicles[i].transform.position.x);
        //crushPosition.y = (icicles[i].transform.position.y - 3);

        //icicles[i].transform.position = Vector2.Lerp(icicles[i].transform.position, crushPosition, 20 * Time.fixedDeltaTime);
        // Vector2.Lerp(icicles[i].transform.position, crushPosition, 5);

        icicles[i].AddComponent<Rigidbody2D>();


//=======
        Debug.Log(i);
        rigid_body[i].gravityScale = 1;
        crushPosition.x = (icicles[i].transform.position.x);
        crushPosition.y = (icicles[i].transform.position.y - 3);
        // icicles[i].transform.position = Vector2.Lerp(icicles[i].transform.position, crushPosition, 5);
        //Vector2.MoveTowards(icicles[i].transform.position, crushPosition, delay * Time.deltaTime);
//>>>>>>> origin/master
=======
        icicles[i].AddComponent<Rigidbody2D>();
>>>>>>> origin/master
    }

    void checkFallChance()
    {
        if (triggered)
        {
            if (i < icicles.Length)
            {
                moveIcicle(i);
                i++;
            }
        }
    }
}

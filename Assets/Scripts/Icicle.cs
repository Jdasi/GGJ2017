using UnityEngine;
using System.Collections;

public class Icicle : MonoBehaviour {
    public GameObject[] icicles;

    public bool triggered = false;

    private int i = 0;
    private int fallChance;

    private Rigidbody2D[] rigid_body;


    void Start () 
    {
        InvokeRepeating("checkFallChance", 0.5f, Random.Range(0.5f, 1.0f));

        for (int i = 0; i < icicles.Length; i++)
        {

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
        icicles[i].AddComponent<Rigidbody2D>();
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

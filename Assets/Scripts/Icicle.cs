using UnityEngine;
using System.Collections;

public class Icicle : MonoBehaviour {
    public GameObject[] icicles;
    public bool triggered = false;
    public float delay = 2.0f;
    public Vector2 crushPosition;
    private int i = 0;
    private int fallChance;

    void Start () {
        InvokeRepeating("checkFallChance", 0.5f, Random.Range(1f, 2.0f));
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
      
        if (triggered)
        {

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            triggered = true;   
        }
    }

    void moveIcicle(int i)
    {
        
        crushPosition.x = (icicles[i].transform.position.x);
        crushPosition.y = (icicles[i].transform.position.y - 3);

        icicles[i].transform.position = Vector2.Lerp(icicles[i].transform.position, crushPosition, 5);
       // Vector2.Lerp(icicles[i].transform.position, crushPosition, 5);
    }

    void checkFallChance()
    {
        if (triggered)
        {
            fallChance = Random.Range(1, 100);
            if (i < icicles.Length)
            {
                moveIcicle(i);
                i++;
            }

        }
    }
}

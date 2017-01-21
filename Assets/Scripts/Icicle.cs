using UnityEngine;
using System.Collections;

public class Icicle : MonoBehaviour {
    public GameObject[] icicles;
    public bool triggered = false;
    public float delay = 2.0f;
    public Vector2 crushPosition;
    private int i = 0;
   // public int integer = 0;

    void Start () {
	    //Collider2D col = GameObject.Find
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (triggered && i < icicles.Length)
        {
          //  icicles[i].transform.position.y -= 1;
            StartCoroutine(ExecuteAfterTime());
            moveIcicle(i);
            i++;
            Debug.Log(i);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            triggered = true;   
        }
    }

    IEnumerator ExecuteAfterTime()
    {
        //Debug.Log(delay);
        yield return new WaitForSeconds(200f);

    }

    void moveIcicle(int i)
    {
        crushPosition.x = (icicles[i].transform.position.x);
        crushPosition.y = (icicles[i].transform.position.y - 5);
        icicles[i].transform.position = Vector2.Lerp(icicles[i].transform.position, crushPosition, 5);
    }
}

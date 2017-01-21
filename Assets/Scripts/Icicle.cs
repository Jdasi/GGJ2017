using UnityEngine;
using System.Collections;

public class Icicle : MonoBehaviour {
    public GameObject[] icicles;
    public bool triggered = false;
   // public Collider2D collider;



    void Start () {
	    //Collider2D col = GameObject.Find
	}
	
	// Update is called once per frame
	void Update () {
        if(triggered)
        {
            for (int i = 0; i < icicles.Length; i++)
            {
                ExecuteAfterTime(200);
                icicles[i].transform.position += Vector3.down * 10 * Time.deltaTime;
                Debug.Log(icicles[i].transform.position);
            }
        }

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("Triggered");
            triggered = true;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
}

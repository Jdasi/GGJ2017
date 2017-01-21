using UnityEngine;
using System.Collections;

public class Icicle : MonoBehaviour {
    public GameObject[] icicles;
    public bool triggered = false;
    public float delay = 2.0f;

    public int integer = 0;

    void Start () {
	    //Collider2D col = GameObject.Find
	}
	
	// Update is called once per frame
	void Update () {
        //if(triggered)
        //{
           
        //}

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            for (int i = 0; i < icicles.Length; i++)
            {
                StartCoroutine(ExecuteAfterTime());
                icicles[i].transform.position += Vector3.down * 10 * Time.deltaTime;
               // integer++;
            }
        }
    }

    IEnumerator ExecuteAfterTime()
    {
        //Debug.Log(delay);
        yield return new WaitForSeconds(2f);

    }
}

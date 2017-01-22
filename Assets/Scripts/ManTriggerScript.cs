using UnityEngine;
using System.Collections;

public class ManTriggerScript : MonoBehaviour {

    GameObject man;

	// Use this for initialization
	void Start () {
       man = GameObject.Find("Man");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Play");
            man.GetComponentInParent<ManScript>().playHelp();
        }
    }
}

using UnityEngine;
using System.Collections;

public class SlipperyFloor : MonoBehaviour {


    private PlayerMovement player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            player.on_ice = true;
        }
    }


    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            player.on_ice = false;
        }
    }
}

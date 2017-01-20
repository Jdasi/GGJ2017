using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
    public int speed = 10;
    public float climbVelocity;
    public float climbSpeed;
    private float gravityStore;
    private PlayerMovement player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player.on_ladder = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player.on_ladder = false;
        }
    }
}

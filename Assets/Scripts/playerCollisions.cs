using UnityEngine;
using System.Collections;

public class playerCollisions : MonoBehaviour {
    public bool playerIsAlive = true;
    public Collider2D hitBox;
    private WorldState world_state; 
	// Use this for initialization
	void Start () {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy" )
        {
            if(world_state.is_hot)
            {
                Debug.Log("Player Dead - Enemy");
            }
            
        }
        if(col.gameObject.tag == "Hazard")
        {
            Debug.Log("Player Dead - Hazard");

        }
    }
}

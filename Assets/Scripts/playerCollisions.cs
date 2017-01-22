using UnityEngine;
using System.Collections;

public class playerCollisions : MonoBehaviour {
    public bool playerIsAlive = true;
    private bool gameOver = false;
    public Collider2D hitBox;
    private WorldState world_state; 
	// Use this for initialization
	void Start () {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
        //hitBox = GetComponent<Collider2D>();
       
    }

    // Update is called once per frame
    void Update () {
	    if(gameOver)
        {
            GameOver();
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col);
        if(col == hitBox)
        {
            Debug.Log("Entered");
            Debug.Log(col.gameObject.tag);

            if (col.tag == "Enemy" )
            {
                if(world_state.is_hot)
                {
                    Debug.Log("Player Dead - Enemy");
                    gameOver = true;
                }
            
            }
            if(col.tag == "HazardHot")
            {
                if (world_state.is_hot)
                {
                    Debug.Log("Player Dead - Hazard (hot)");
                    gameOver = true;
                }
            }
            if (col.gameObject.tag == "HazardCold")
            {
                if (!world_state.is_hot)
                {
                    Debug.Log("Player Dead - Hazard (cold)");
                    gameOver = true;
                }
            }
        }
    }

    void GameOver()
    {
        Application.LoadLevel("Game Over");
    }
}

using UnityEngine;
using System.Collections;

public class Hazards : MonoBehaviour {
    private bool gameOver = false;
    private WorldState world_state;
    public bool hotHazard = false;

    void Start()
    {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Entered");
            if (world_state.is_hot)
            {
                if (hotHazard)
                {
                    Debug.Log("Player Dead - hot");
                    gameOver = true;
                }
            }
            else if (!world_state.is_hot)
            {
                if (!hotHazard)
                {
                    Debug.Log("Player Dead - cold");
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

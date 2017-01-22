using UnityEngine;
using System.Collections;

public class Hazards : MonoBehaviour
{
    private WorldState world_state;

    public bool hotHazard = false;

    public AudioSource audio_source;
    public AudioClip click;

    private PlayerLives player_lives;

    void Start()
    {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
        player_lives = GameObject.Find("Player").GetComponent<PlayerLives>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (world_state.is_hot)
            {
                if (hotHazard)
                {
                    player_lives.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    player_lives.gameObject.GetComponent<CircleCollider2D>().enabled = false;

                    player_lives.remove_life();
                }
            }
            else if (!world_state.is_hot)
            {
                if (!hotHazard)
                {
                    player_lives.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    player_lives.gameObject.GetComponent<CircleCollider2D>().enabled = false;

                    player_lives.remove_life();
                }
            }
        }
        
    }
}

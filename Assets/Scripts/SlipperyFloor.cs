using UnityEngine;
using System.Collections;

public class SlipperyFloor : MonoBehaviour {

    private WorldState world_state;
    private PlayerMovement player;
    bool slippy = true;
    public Sprite cold;
    public Sprite hot;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();

        world_state.kinda_heatwave_objects.Add(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeatWaveSource")
        {
            checkTemp();
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (slippy)
        {
            if (coll.tag == "Player")
            {
                player.on_ice = true;
            }
        }

        else
        {
            player.on_ice = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            player.on_ice = false;
        }
    }

    public void react()
    {
        checkTemp();
    }

    void checkTemp()
    {
        if (world_state.is_hot)
        {
            slippy = false;
            GetComponent<SpriteRenderer>().sprite = hot;
        }

        else
        {
            slippy = true;
            GetComponent<SpriteRenderer>().sprite = cold;
        }
    }
}

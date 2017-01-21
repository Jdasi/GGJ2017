using UnityEngine;
using System.Collections;

public class HeatWaveObject : MonoBehaviour
{
    // TEMP STUFF WHILE WE WAIT FOR ART
    public Sprite cold_sprite;
    public Sprite hot_sprite;

    public bool visible_in_cold = true;
    public bool visible_in_hot = true;

    private WorldState world_state;
    private SpriteRenderer sprite;

	void Start()
    {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {

	}

    public void react()
    {
        if (!world_state.is_hot && visible_in_cold)
            gameObject.SetActive(true);
        else if (world_state.is_hot && visible_in_hot)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);

        sprite.sprite = world_state.is_hot ? hot_sprite : cold_sprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeatWaveSource")
        {
            print("HeatWaveObject collision");

            react();
        }
    }
}

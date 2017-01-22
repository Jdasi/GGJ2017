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
    private BoxCollider2D box_collider;

	void Start()
    {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
        sprite = GetComponent<SpriteRenderer>();
        box_collider = GetComponent<BoxCollider2D>();
	}
	
	void Update ()
    {

	}

    public void react()
    {
        if (!world_state.is_hot && visible_in_cold)
        {
            sprite.enabled = true;
            box_collider.isTrigger = false;
        }
        else if (world_state.is_hot && visible_in_hot)
        {
            sprite.enabled = true;
            box_collider.isTrigger = false;
        }
        else
        {
            sprite.enabled = false;
            box_collider.isTrigger = true;
        }

        sprite.sprite = world_state.is_hot ? hot_sprite : cold_sprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeatWaveSource")
        {
            react();
        }
    }
}

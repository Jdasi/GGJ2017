using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    // TEMP STUFF WHILE WE WAIT FOR ART
    public Color cold_color = Color.cyan;
    public Color hot_color = Color.red;

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

    public void transition()
    {
        if (!world_state.is_hot && visible_in_cold)
            gameObject.SetActive(true);
        else if (world_state.is_hot && visible_in_hot)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);

        sprite.color = world_state.is_hot ? hot_color : cold_color;
    }
}

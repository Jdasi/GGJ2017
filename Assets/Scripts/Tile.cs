using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    // TEMP STUFF WHILE WE WAIT FOR ART
    public Color cold_color = Color.cyan;
    public Color hot_color = Color.red;

    public bool visible_in_cold = true;
    public bool visible_in_hot = true;

    private HeatWave heat_wave;
    private SpriteRenderer sprite;

	void Start()
    {
        heat_wave = GameObject.Find("HeatWaveManager").GetComponent<HeatWave>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {

	}

    public void transition()
    {
        if (!heat_wave.active && visible_in_cold)
            gameObject.SetActive(true);
        else if (heat_wave.active && visible_in_hot)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);

        sprite.color = heat_wave.active ? hot_color : cold_color;
    }
}

using UnityEngine;
using System.Collections;

public class WorldState : MonoBehaviour
{
    public bool is_hot = false;

    public HeatWaveObject[] tiles;

	void Start()
    {
        tiles = GameObject.FindObjectsOfType<HeatWaveObject>();

        foreach (HeatWaveObject tile in tiles)
        {
            tile.react();
        }
	}
	
	void Update()
    {
        if (Input.GetButtonDown("HeatWave"))
        {
            is_hot = !is_hot;

            foreach (HeatWaveObject tile in tiles)
            {
                tile.react();
            }
        }
	}
}

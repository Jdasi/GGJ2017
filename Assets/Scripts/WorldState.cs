using UnityEngine;
using System.Collections;

public class WorldState : MonoBehaviour
{
    public bool is_hot = false;

    public Tile[] tiles;

	void Start()
    {
        tiles = GameObject.FindObjectsOfType<Tile>();

        foreach (Tile tile in tiles)
        {
            tile.transition();
        }
	}
	
	void Update()
    {
        if (Input.GetButtonDown("HeatWave"))
        {
            is_hot = !is_hot;

            foreach (Tile tile in tiles)
            {
                tile.transition();
            }
        }
	}
}

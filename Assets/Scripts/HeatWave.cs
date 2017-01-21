using UnityEngine;
using System.Collections;

public class HeatWave : MonoBehaviour
{
    public bool active = false;

    Tile[] tiles;

	void Start()
    {
        tiles = GameObject.FindObjectsOfType<Tile>();
	}
	
	void Update()
    {
        if (Input.GetButtonDown("HeatWave"))
        {   
            active = !active;

            foreach (Tile tile in tiles)
            {
                tile.transition();
            }
        }
	}
}

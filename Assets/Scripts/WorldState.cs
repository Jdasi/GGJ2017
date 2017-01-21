using UnityEngine;
using System.Collections;

public class WorldState : MonoBehaviour
{
<<<<<<< HEAD
 //   public bool is_hot = false;

 //   public Tile[] tiles;

	//void Start()
 //   {
 //       tiles = GameObject.FindObjectsOfType<Tile>();

 //       foreach (Tile tile in tiles)
 //       {
 //           tile.transition();
 //       }
	//}
	
	//void Update()
 //   {
 //       if (Input.GetButtonDown("HeatWave"))
 //       {
 //           is_hot = !is_hot;

 //           foreach (Tile tile in tiles)
 //           {
 //               tile.transition();
 //           }
 //       }
	//}
=======
    public bool is_hot = false;
    public HeatWaveObject[] tiles;
    public float heat_wave_speed = 20.0f;

    private bool expanding = false;
    private CircleCollider2D circle_collider;

	void Start()
    {
        tiles = GameObject.FindObjectsOfType<HeatWaveObject>();
        circle_collider = GetComponent<CircleCollider2D>();

        foreach (HeatWaveObject obj in tiles)
        {
            obj.react();
        }
	}
	
	void Update()
    {
        if (expanding)
        {
            circle_collider.radius += heat_wave_speed * Time.deltaTime;
        }

        if (Input.GetButtonDown("HeatWave"))
        {
            expanding = true;
            is_hot = true;
        }
	}
>>>>>>> origin/master
}

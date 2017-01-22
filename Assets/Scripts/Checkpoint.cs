using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
	void Start()
    {

	}
	
	void Update()
    {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Checkpoint hit: " + name);

            collider.GetComponent<PlayerLives>().last_checkpoint = transform.position;
        }
    }
}

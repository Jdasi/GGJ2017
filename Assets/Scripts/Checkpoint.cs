using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    private bool can_activate = true;

	void Start()
    {
    
	}
	
	void Update()
    {

	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!can_activate)
            return;

        if (collider.gameObject.tag == "Player")
        {
            can_activate = false;

            collider.GetComponent<PlayerLives>().last_checkpoint = transform.position;
        }
    }
}

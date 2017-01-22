using UnityEngine;
using System.Collections;

public class TriggerFinish : MonoBehaviour
{

	void Start()
    {
	
	}
	
	void Update()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
            return;

        Application.LoadLevel("End");
    }
}

using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    private bool can_activate = true;
    private AudioSource audio_source;
    public AudioClip checkpoint;
    void Start()
    {
        audio_source = GetComponent<AudioSource>();
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
            audio_source.PlayOneShot(checkpoint);
            can_activate = false;

            collider.GetComponent<PlayerLives>().last_checkpoint = transform.position;
        }
    }
}

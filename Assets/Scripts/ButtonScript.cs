using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    bool moveDoor = false;

    float timeLeft = 4;
    private AudioSource audio_source;
    public AudioClip open;

    private SpriteRenderer instruction;

    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        instruction = GameObject.Find("XtoInteract").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            if (Input.GetButtonDown("Interact"))
            {
                moveDoor = true;
                audio_source.PlayOneShot(open);
            }

            if (moveDoor)
            {
                GameObject door = GameObject.Find("Door");

                door.transform.position += Vector3.down * 1 * Time.deltaTime;
                
                timeLeft -= Time.deltaTime;

                if (timeLeft < 0)
                {
                    moveDoor = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
            return;

        instruction.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
            return;

        instruction.enabled = false;
    }
}

using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    bool moveDoor = false;

    float timeLeft = 4;
    private AudioSource audio_source;
    public AudioClip open;
    void Start()
    {
        audio_source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            if (Input.GetButtonDown("Interact"));
            {
                moveDoor = true;
                audio_source.PlayOneShot(open);
                //play click sound
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
}

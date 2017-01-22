using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
    public bool dropBridge = false;
    public bool entered = false;

    private GameObject platform;
    private AudioSource audio_source;
    public AudioClip click;

    Vector3 rotationEuler;
    Vector3 initialPosition;
    Vector3 downPosition;

    private float currentTime = 0;

    bool moveDirection = true;
    bool move = false;

    private GameObject player;

	void Start ()
    {
        platform = GameObject.Find("Platform");
        audio_source = GetComponent<AudioSource>();

        initialPosition = transform.position;
        downPosition = transform.position;
        downPosition.y -= 0.05f;

        player = GameObject.Find("Player");
	}


    void Update () {

        if ((platform.transform.position.y < 2) || (platform.transform.position.y > 7))
        {
            if (moveDirection)
            {
                moveDirection = false;
            }

            else
            {
                moveDirection = true;
            }
        }

        if (move)
        {
            if (platform.transform.position.y > 2)
            {
                platform.transform.position += Vector3.down * 1 * Time.deltaTime;
            }     
        }

        else
        {
            if (platform.transform.position.y < 7)
            {
                platform.transform.position += Vector3.down * -1 * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeatWaveSource")
            return;

        if (Vector3.Distance(transform.position, player.transform.position) < 10f)
            audio_source.PlayOneShot(click);

        transform.position = downPosition;
    }
    void OnTriggerStay2D()
    {
        move = true;
    }

    void OnTriggerExit2D()
    {
        move = false;
        transform.position = initialPosition;
    }
}

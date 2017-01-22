using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
    public bool dropBridge = false;
    public bool entered = false;
    private GameObject platform;
    Vector3 rotationEuler;
    Vector3 initialPosition;
    Vector3 downPosition;
    private float currentTime = 0;
    bool moveDirection = true;
    bool move = false;

	void Start () {
        platform = GameObject.Find("Platform");
        initialPosition = transform.position;
        downPosition = transform.position;
        downPosition.y -= 1;
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

    void OnTriggerEnter2D()
    {
        //currentTime = 0;
    }
    void OnTriggerStay2D()
    {
        move = true;
        transform.position = downPosition;
    }

    void OnTriggerExit2D()
    {
        move = false;
        transform.position = downPosition;
    }
}

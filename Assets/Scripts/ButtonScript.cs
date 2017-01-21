using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    bool moveDoor = false;

    float timeLeft = 3;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        //if player is nearby
        //if player presses gamepad interact key

        if (GetComponent<Renderer>().isVisible)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                moveDoor = true;
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

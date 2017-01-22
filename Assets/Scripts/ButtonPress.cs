using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
    public bool dropBridge = false;
    public bool entered = false;
    private GameObject platform;
    Vector3 rotationEuler;
    private float currentTime = 0;
    bool moveDirection = true;
    bool move = false;

	void Start () {
        platform = GameObject.Find("Platform");
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

        //if player on trigger and not fully dropped
        //print(transform.rotation.eulerAngles);
        /* if (dropBridge)
         {
             if (currentTime <= 3)
             {
                 currentTime += Time.deltaTime;

                 rotationEuler -= Vector3.forward * 30 * Time.deltaTime; //increment 30 degrees every second
                 bridge.transform.rotation = Quaternion.Euler(rotationEuler);
                 Debug.Log(currentTime);
             }
         }
         else if (!dropBridge && entered)
         {
             if (currentTime <= 3)
             {
                 Debug.Log(currentTime);
                 currentTime += Time.deltaTime;
                 rotationEuler += Vector3.forward * 31 * Time.deltaTime; //increment 30 degrees every second
                 bridge.transform.rotation = Quaternion.Euler(rotationEuler);
             }
         }*/
    }

    void OnTriggerEnter2D()
    {
        //currentTime = 0;
    }
    void OnTriggerStay2D()
    {
        move = true;
        //entered = true;
        //dropBridge = true;
    }

    void OnTriggerExit2D()
    {
        move = false;
        //currentTime = 0;
        //dropBridge = false;
    }
}

using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
    public bool dropBridge = false;
    public bool stopRotation = true;
    private float timeLeft = 3;
    private GameObject bridge;
    Vector3 rotationEuler;


	void Start () {
        bridge = GameObject.Find("Drawbridge");
	}


    void Update () {
        //if player on trigger and not fully dropped

        print(transform.rotation.eulerAngles);
	    if (dropBridge)
        {
            if(bridge.transform.rotation.z < -0.75)
            {
                Debug.Log(bridge.transform.rotation.z);
                rotationEuler -= Vector3.forward * 30 * Time.deltaTime; //increment 30 degrees every second
                bridge.transform.rotation = Quaternion.Euler(rotationEuler);
            }            
        }
        else if(!dropBridge)
        {
            if (bridge.transform.rotation.z > -0.75)
            {
                rotationEuler += Vector3.forward * 30 * Time.deltaTime; //increment 30 degrees every second
                bridge.transform.rotation = Quaternion.Euler(rotationEuler);
            }
        }

    }


    void OnTriggerStay2D()
    {
        dropBridge = true;
    }

    void OnTriggerExit2D()
    {
        dropBridge = false;
    }
}

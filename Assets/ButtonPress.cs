using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
    public bool dropBridge = false;
    public bool stopRotation = true;
    private float timeLeft = 3;
    private GameObject bridge;
    Vector3 rotationEuler;
	// Use this for initialization
	void Start () {
        bridge = GameObject.Find("Drawbridge");
	}


    void Update () {
        //if player on trigger and not fully dropped

        //To convert Quaternion -> Euler, use eulerAngles
        print(transform.rotation.eulerAngles);
	    if (dropBridge)
        {
            if(bridge.transform.localRotation.z < 90)
            {
                rotationEuler += Vector3.forward * 30 * Time.deltaTime; //increment 30 degrees every second
                bridge.transform.rotation = Quaternion.Euler(rotationEuler);

            }
            //bridge.transform.Rotate(0, 0, 90);
            
        }
        else if(!dropBridge)
        {
            //if (bridge.transform.localRotation.z > 90)
            //    bridge.transform.Rotate(0, 0, 0);
            
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

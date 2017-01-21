using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
    public bool dropBridge = false;
    public bool entered = false;
    private GameObject bridge;
    Vector3 rotationEuler;
    private float currentTime = 0;

	void Start () {
        bridge = GameObject.Find("Drawbridge");
	}


    void Update () {
        //if player on trigger and not fully dropped
        //print(transform.rotation.eulerAngles);
        if (dropBridge)
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
                rotationEuler += Vector3.forward * 30 * Time.deltaTime; //increment 30 degrees every second
                bridge.transform.rotation = Quaternion.Euler(rotationEuler);
            }
        }

    }

    void OnTriggerEnter2D()
    {
        currentTime = 0;
    }
    void OnTriggerStay2D()
    {
        entered = true;
        dropBridge = true;
    }

    void OnTriggerExit2D()
    {
        currentTime = 0;
        dropBridge = false;
    }
}

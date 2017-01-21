using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
    public bool dropBridge = false;
    private float timeLeft = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (dropBridge)
        {
            GameObject bridge = GameObject.Find("Drawbridge");
            Debug.Log("bridge found");
            //bridge.transform.position += Vector3.down * 1 * Time.deltaTime;
            bridge.transform.Rotate(0, 0, -90 * Time.deltaTime);
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                dropBridge = false;
            }
        }
	}
    void OnTriggerEnter2D()
    {
        Debug.Log("")
        dropBridge = true;
        transform.position += Vector3.down * 1 * Time.deltaTime;
    }
}

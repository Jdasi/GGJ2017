using UnityEngine;
using System.Collections;

public class OnScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //checkOnScreen();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool checkOnScreen()
    {
        /*if (GetComponent<Renderer>().isVisible)
        {
            return true;
        }

        else
        {
            return false;
        }*/
        return true;
    }
}

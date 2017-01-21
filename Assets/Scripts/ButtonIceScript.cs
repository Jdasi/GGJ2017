using UnityEngine;
using System.Collections;

public class ButtonIceScript : MonoBehaviour {

    bool isAlive = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	

        if (isAlive)
        {
            GameObject background = GameObject.Find("BackgroundColour");

            if (background.GetComponent<BackgroundColour>().isCold != true)
            {
                Destroy(gameObject);
            }
        }
	}
}

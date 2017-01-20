using UnityEngine;
using System.Collections;

public class BackgroundColour : MonoBehaviour {
    public bool isCold = true;
    Color lerpedcolor = Color.white;
    Color colourFrom = Color.blue;
    Color colourTo = Color.red; 
    

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKeyDown("space"))
        {
            if (isCold == true)
            {
                isCold = false;
            }
            else
                isCold = true; 
       }
        switch (isCold)
        {
            case true:
                colourFrom = Color.red;
                colourTo = Color.blue;
                break;
            case false:
                colourFrom = Color.blue;
                colourTo = Color.red;
                break;
        }
        lerpedcolor = Color.Lerp(colourFrom, colourTo, Mathf.PingPong(Time.time, 1));
        GetComponent<SpriteRenderer>().color = lerpedcolor; 
    }
}


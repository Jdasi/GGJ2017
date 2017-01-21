using UnityEngine;
using System.Collections;

public class WindScript : MonoBehaviour {

    float windSpeed = 3;
    float maxDistance = 10;
    bool cold = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (cold == true)
        {
            if (coll.tag == "Player")
            {
                coll.GetComponent<Rigidbody2D>().AddForce(transform.right * -17.5f);

                //play wind sound 
            }
        }
    }

    void checkCold()
    {
        GameObject background = GameObject.Find("Winter");
        if (background.GetComponent<WinterBackground>().isCold)
        {
            cold = true;
        }

        else
        {
            cold = false;
        }
    }
}

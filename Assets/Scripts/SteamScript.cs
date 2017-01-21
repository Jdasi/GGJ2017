using UnityEngine;
using System.Collections;

public class SteamScript : MonoBehaviour {

    bool cold = true;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        checkCold();
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (cold == false)
        {
            if (coll.tag == "Player")
            {
                coll.GetComponent<Rigidbody2D>().AddForce(transform.up * 20);
                coll.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            }
        }
    }

    void checkCold()
    {
        GameObject steam = GameObject.Find("Steam particle effect");

        GameObject background = GameObject.Find("Winter");
        if (background.GetComponent<WinterBackground>().isCold)
        {
            cold = true;
            //  steam.GetComponent<ParticleSystem>().Stop();

            steam.GetComponent<ParticleSystem>().enableEmission = false;
        }

        else
        {
            cold = false;
            // steam.GetComponent<ParticleSystem>().Play();

            steam.GetComponent<ParticleSystem>().enableEmission = true;
        }
    }
}

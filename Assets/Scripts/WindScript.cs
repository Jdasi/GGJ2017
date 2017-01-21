using UnityEngine;
using System.Collections;

public class WindScript : MonoBehaviour {

    float windSpeed = 3;
    float maxDistance = 10;
    bool cold = true;
    private WorldState world_state;

    // Use this for initialization
    void Start () {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
    }
	
	// Update is called once per frame
	void Update () {
        checkCold();
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (cold == true)
        {
            if (coll.tag == "Player")
            {
                coll.GetComponent<Rigidbody2D>().AddForce(transform.right * -18f);

                //play wind sound 
            }
        }
    }

    void checkCold()
    {
        GameObject wind  = GameObject.Find("Wind particle effect");

        if (!world_state.is_hot)
        {
            cold = true;
            wind.GetComponent<ParticleSystem>().enableEmission = true;
        }

        else
        {
            cold = false;
            wind.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
}

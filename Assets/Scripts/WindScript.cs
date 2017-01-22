using UnityEngine;
using System.Collections;

public class WindScript : MonoBehaviour {

    float windSpeed = 3;
    float maxDistance = 10;
    private WorldState world_state;
    GameObject wind;

    // Use this for initialization
    void Start () {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();

       world_state.kinda_heatwave_objects.Add(gameObject);

        wind = GameObject.Find("Wind effect");
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (!world_state.is_hot)
        {
            if (coll.tag == "Player")
            {
                coll.GetComponent<Rigidbody2D>().AddForce(transform.right * -18f);

                //play wind sound 
            }
        }
    }

    public void react()
    {
        checkCold();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeatWaveSource")
        {
            checkCold();
        }
    }

    void checkCold()
    {
        if (!world_state.is_hot)
        {
            //wind.GetComponent<ParticleSystem>().enableEmission = true;
            wind.GetComponent<ParticleSystem>().Play();
        }

        else
        {
            //wind.GetComponent<ParticleSystem>().enableEmission = false;
            wind.GetComponent<ParticleSystem>().Stop();
        }
    }
}

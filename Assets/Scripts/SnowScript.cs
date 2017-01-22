using UnityEngine;
using System.Collections;

public class SnowScript : MonoBehaviour {

    private WorldState world_state;

    // Use this for initialization
    void Start () {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!world_state.is_hot)
        {
            GetComponent<ParticleSystem>().enableEmission = true;
        }

        else
        {
            GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
}

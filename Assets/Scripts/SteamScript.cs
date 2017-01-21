using UnityEngine;
using System.Collections;

public class SteamScript : MonoBehaviour {

    //bool cold = true;
    private WorldState world_state;

    // Use this for initialization
    void Start ()
    {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
    }

    // Update is called once per frame
    void Update()
    {
        checkCold();
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (world_state.is_hot)
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
        if (!world_state.is_hot)
        {
            //cold = true;

            steam.GetComponent<ParticleSystem>().enableEmission = false;
        }

        else
        {
            //cold = false;

            steam.GetComponent<ParticleSystem>().enableEmission = true;
        }
    }
}

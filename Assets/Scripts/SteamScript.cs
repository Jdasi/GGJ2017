﻿using UnityEngine;
using System.Collections;

public class SteamScript : MonoBehaviour {

    //bool cold = true;
    private WorldState world_state;
    private AudioSource audio_source;
    public AudioClip steam;

    // Use this for initialization
    void Start ()
    {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();
        audio_source = GetComponent<AudioSource>();
        world_state.kinda_heatwave_objects.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        audio_source.PlayOneShot(steam);
        if (world_state.is_hot)
        {
            if (coll.tag == "Player")
            {
                coll.GetComponent<Rigidbody2D>().AddForce(transform.up * 25);
                coll.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            }
        }
    }

    void checkCold()
    {
        GameObject steam = GameObject.Find("Steam particle effect");

        if (!world_state.is_hot)
        {
            steam.GetComponent<ParticleSystem>().enableEmission = false;
        }

        else
        {
            steam.GetComponent<ParticleSystem>().enableEmission = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeatWaveSource")
        {
            checkCold();
        }
    }

    public void react()
    {
        checkCold();
    }
}

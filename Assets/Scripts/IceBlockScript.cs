﻿using UnityEngine;
using System.Collections;

public class IceBlockScript : MonoBehaviour
{
    bool isFrozen = true;
    private WorldState world_state;

    // Use this for initialization
    void Start()
    {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();

        world_state.kinda_heatwave_objects.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        checkTemp();
    }

    void checkTemp()
    {
        if (!world_state.is_hot)
        {
            isFrozen = true;
        }

        else 
        {
            isFrozen = false;
        }
    }

    void changeOpacity()
    {
        if (isFrozen != true)
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            GetComponent<SpriteRenderer>().color = tmp;
        }

        else
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    void changeCollider()
    {
        if (isFrozen != true)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        else
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeatWaveSource")
        {
            changeOpacity();
            changeCollider();
        }
    }

    public void react()
    {
        changeOpacity();
        changeCollider();
    }
}

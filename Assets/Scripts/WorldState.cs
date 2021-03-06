﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldState : MonoBehaviour
{
    public bool is_hot = false;
    public HeatWaveObject[] heatwave_objects;
    public List<GameObject> kinda_heatwave_objects;
    public float expand_duration = 1f;

    public AudioClip cold_wave;
    public AudioClip heat_wave;

    private float max_heatwave_radius = 100f;
    private float heatwave_cooldown;

    private bool expanding = false;
    private CircleCollider2D circle_collider;
    private SpriteRenderer heatwave_sprite;
    private AudioSource audio_source;

    private float timer = 0f;
    private float size_counter = 0f;

    void Start()
    {
        heatwave_objects = GameObject.FindObjectsOfType<HeatWaveObject>();
        circle_collider = GetComponent<CircleCollider2D>();
        heatwave_sprite = GameObject.Find("HeatWaveSprite").GetComponent<SpriteRenderer>();
        audio_source = transform.parent.gameObject.GetComponentInChildren<AudioSource>();

        heatwave_cooldown = expand_duration;

        Invoke("react_all", 0.1f);
    }
    
    void Update()
    {
        if (expanding)
        {
            size_counter += Time.deltaTime;
            circle_collider.radius = Mathf.Lerp(0f, max_heatwave_radius, size_counter / expand_duration);
            heatwave_sprite.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(40, 40, 1), size_counter / expand_duration);
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (expanding)
            {
                expanding = false;
                timer = 0f;
                circle_collider.radius = 0f;
                heatwave_sprite.transform.localScale = Vector3.zero;
                react_all();
            }
        }

        if (Input.GetButtonDown("HeatWave") && timer == 0f)
        {
            expanding = true;
            is_hot = !is_hot;

            audio_source.clip = is_hot ? heat_wave : cold_wave;
            audio_source.Play();

            timer = heatwave_cooldown;
            size_counter = 0f;
            circle_collider.radius = 0f;
            heatwave_sprite.transform.localScale = Vector3.one;

            heatwave_sprite.color = is_hot ? new Color(1, 0, 0, 0.33f) : new Color(0, 1, 1, 0.33f);
        }
    }

    void react_all()
    {
        foreach (HeatWaveObject obj in heatwave_objects)
        {
            obj.react();
        }

        foreach (GameObject obj in kinda_heatwave_objects)
        {
            obj.SendMessage("react");
        }
    }
}

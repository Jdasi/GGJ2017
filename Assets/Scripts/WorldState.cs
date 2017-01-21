using UnityEngine;
using System.Collections;

public class WorldState : MonoBehaviour
{
    public bool is_hot = false;
    public HeatWaveObject[] heatwave_objects;
    public float expand_duration = 1f;

    private float max_heatwave_radius = 100f;
    private float heatwave_cooldown;

    private bool expanding = false;
    private CircleCollider2D circle_collider;

    private float timer = 0f;
    private float size_counter = 0f;

    void Start()
    {
        heatwave_objects = GameObject.FindObjectsOfType<HeatWaveObject>();
        circle_collider = GetComponent<CircleCollider2D>();

        heatwave_cooldown = expand_duration;

        react_all();
    }
    
    void Update()
    {
        if (expanding)
        {
            size_counter += Time.deltaTime;
            circle_collider.radius = Mathf.Lerp(0f, max_heatwave_radius, size_counter / expand_duration);
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
                react_all();
            }
        }

        if (Input.GetButtonDown("HeatWave") && timer == 0f)
        {
            expanding = true;
            is_hot = !is_hot;

            timer = heatwave_cooldown;
            size_counter = 0f;
            circle_collider.radius = 0f;
        }
    }

    void react_all()
    {
        foreach (HeatWaveObject obj in heatwave_objects)
        {
            obj.react();
        }
    }
}

using UnityEngine;
using System.Collections;

public class ManScript : MonoBehaviour
{

    bool isFrozen = true;
    public Sprite alive;
    public Sprite dead;
    public float deathHeight = -1;
    float timeLeft = 0.2f;
    bool isDead = false;
    private WorldState world_state;
    private AudioSource audio_source;
    public AudioClip death_sound;

    // Use this for initialization
    void Start()
    {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();

        world_state.kinda_heatwave_objects.Add(gameObject);

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        GetComponent<SpriteRenderer>().color = tmp;

        audio_source = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (world_state.is_hot)
        {
            checkHeight();
        }

        if (isDead)
        {
            timeLeft -= Time.deltaTime;
        }

        if (timeLeft < 0)
        {
            Destroy(gameObject);

            audio_source.PlayOneShot(death_sound);

            world_state.kinda_heatwave_objects.Remove(gameObject);
        }
    }

    void enableGrav()
    {
        if (!world_state.is_hot)
        {
            return;
        }

        GameObject ice = GameObject.Find("Man Ice");

        Destroy(ice);

        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        GetComponent<SpriteRenderer>().color = tmp;

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

    }

    void checkHeight()
    {
        if (transform.position.y < deathHeight)
        {
            GetComponent<SpriteRenderer>().sprite = dead;

            isDead = true;

            transform.localScale *= 1.3f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeatWaveSource")
        {
            enableGrav();
        }
    }

    public void react()
    {
        enableGrav();
    }

    public void playHelp()
    {
        audio_source.Play();
    }
}

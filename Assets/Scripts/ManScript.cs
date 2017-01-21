using UnityEngine;
using System.Collections;

public class ManScript : MonoBehaviour {

    bool isFrozen = true;
    public Sprite alive;
    public Sprite dead;
    public float deathHeight = -1;
    float timeLeft = 0.2f;
    bool isDead = false;
    private WorldState world_state;

    // Use this for initialization
    void Start () {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        GetComponent<SpriteRenderer>().color = tmp;
    }
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<Renderer>().isVisible)
        {
            checkTemp();

            if (isFrozen == false)
            {
                enableGrav();
            }
        }

        if (isFrozen == false)
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
        }
    }

    void checkTemp()
    {
        GameObject state = GameObject.Find("Wind particle effect");

        if (!world_state.is_hot)
        {
            isFrozen = true;
        }

        else 
        {
            isFrozen = false;
        }
    }

    void enableGrav()
    {
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
        }
    }
}

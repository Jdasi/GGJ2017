using UnityEngine;
using System.Collections;

public class ManScript : MonoBehaviour {

    bool isFrozen = true;
    public Sprite alive;
    public Sprite dead;
    public float deathHeight = -1;
    float timeLeft = 0.2f;
    bool isDead = false;

    // Use this for initialization
    void Start () {
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

            if (isFrozen == true)
            {
                enableGrav();
            }
        }

        if (isFrozen == true)
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
        GameObject background = GameObject.Find("Winter");
        if (background.GetComponent<WinterBackground>().isCold)
        {
            isFrozen = true;
        }

        else if (background.GetComponent<WinterBackground>().isCold != true)
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

        isFrozen = true;
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

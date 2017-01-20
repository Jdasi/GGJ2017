using UnityEngine;
using System.Collections;

public class IceBlockScript : MonoBehaviour
{

    bool isFrozen = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        checkTemp();
    }

    void checkTemp()
    {
        //if isCold
        {
            isFrozen = true;
            changeOpacity();
            changeCollider();
        }

        //else if isCold != true
        {
            isFrozen = false;
            changeOpacity();
            changeCollider();
        }
    }

    void changeOpacity()
    {
        if (isFrozen)
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            GetComponent<SpriteRenderer>().color = tmp;
        }

        else
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 0.2f;
            GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    void changeCollider()
    {
        if (isFrozen)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        else
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}

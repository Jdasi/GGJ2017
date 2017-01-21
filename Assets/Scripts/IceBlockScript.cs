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
        if (GetComponent<OnScreenScript>().checkOnScreen())
        {
            checkTemp();
        }
    }

    void checkTemp()
    {
        GameObject background = GameObject.Find("Winter");
        if (background.GetComponent<WinterBackground>().isCold)
        {
           // Debug.Log("cold");

            isFrozen = true;
            changeOpacity();
            changeCollider();
        }

        else if (background.GetComponent<WinterBackground>().isCold != true)
        {
            //Debug.Log("hot");
            isFrozen = false;
            changeOpacity();
            changeCollider();
        }
    }

    void changeOpacity()
    {
        if (isFrozen != true)
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 0.1f;
            GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    void changeCollider()
    {
        if (isFrozen != true)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}

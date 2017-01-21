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
        GameObject background = GameObject.Find("BackgroundColour");
        if (background.GetComponent<BackgroundColour>().isCold)
        {
            isFrozen = true;
            changeOpacity();
            changeCollider();
        }

        else if (background.GetComponent<BackgroundColour>().isCold != true)
        {
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

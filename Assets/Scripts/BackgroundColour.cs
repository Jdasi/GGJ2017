using UnityEngine;
using System.Collections;

public class BackgroundColour : MonoBehaviour
{
    bool isCold = true;
    public float floatAlpha = 0;
    Color lerpedcolor = Color.white;
    float counter = 0;
    // Use this for initialization
    void Start()
    {
    }

    //  Update is called once per frame
    void Update()
    {
        //GameObject background = GameObject.Find("Winter");
        //isCold = background.GetComponent<WinterBackground>().isCold;
        Color alpha = GetComponent<SpriteRenderer>().color;
        if (Input.GetKeyDown("space"))
        {
            if (alpha.a == 1 || alpha.a <= 0)
            {
                if (isCold == true)
                {
                    isCold = false;
                }
                else
                {
                    isCold = true;
                }
                counter = 0;
            }
           
        }
        switch (isCold)
        {
            case true:
                if (alpha.a > 0.0)
                {
                    alpha.a -= 0.01f;
                }
               // GetComponent<SpriteRenderer>().color = Color.Lerp(Color.blue, Color.red, counter += Time.deltaTime);
                break;
            case false:
                if (alpha.a < 1)
                {
                    alpha.a += 0.01f;
                }
               // GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.blue, counter += Time.deltaTime);
                break;
        }
        GetComponent<SpriteRenderer>().color = alpha;
        floatAlpha = alpha.a;
    }
}




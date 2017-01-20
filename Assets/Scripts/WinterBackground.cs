using UnityEngine;
using System.Collections;

public class WinterBackground : MonoBehaviour {
    public bool isCold = true;
    Color lerpedcolor = Color.white;
    float counter = 0;

    public float hotness = 0;
    public float coldness = 100;
    // Use this for initialization
    void Start()
    {
       
    }

    //  Update is called once per frame
    void Update()
    {
        Color alpha = GetComponent<SpriteRenderer>().color;
        if (Input.GetKeyDown("space"))
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
        switch (isCold)
        {
            case true:
                if (alpha.a < 1)
                {
                    alpha.a += 0.01f; 
                }
                GetComponent<SpriteRenderer>().color = Color.Lerp(Color.blue, Color.red, counter += Time.deltaTime);
                break;
            case false:
                if (alpha.a > -0.99)
                {
                    alpha.a -= 0.01f;
                }
                GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.blue, counter += Time.deltaTime);
                break;
        }
        GetComponent<SpriteRenderer>().color = alpha;
    }
}
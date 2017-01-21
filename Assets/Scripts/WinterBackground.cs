using UnityEngine;
using System.Collections;

public class WinterBackground : MonoBehaviour {
    public bool isCold = true;
    public float floatAlpha = 0;
    public Material mat1;
    public Material mat2;
    Color alpha;
    float counter = 0;
    bool inTransition = false;
    // Use this for initialization
    void Start()
    {
       
    }

    //  Update is called once per frame
    void Update()
    {
        alpha = GetComponent<SpriteRenderer>().color;
        if (Input.GetKeyDown("space"))
        {
            if (alpha.a == 1 || alpha.a < 0)
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
                if (alpha.a < 1)
                {
                    alpha.a += 0.01f; 
                }
                GetComponent<SpriteRenderer>().material.Lerp(mat1, mat2, counter += Time.deltaTime);
                    //= Color.Lerp(Color.blue, Color.red, counter += Time.deltaTime);
                break;
            case false:
                if (alpha.a > 0)
                {
                    alpha.a -= 0.01f;
                }
                GetComponent<SpriteRenderer>().material.Lerp(mat2, mat1, counter += Time.deltaTime);
                //= Color.Lerp(Color.red, Color.blue, counter += Time.deltaTime);
                break;
        }
        //GetComponent<SpriteRenderer>().color = alpha;
        floatAlpha = alpha.a; 
    }
}
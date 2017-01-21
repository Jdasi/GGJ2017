using UnityEngine;
using System.Collections;

public class BackgroundColour : MonoBehaviour
{
    bool isHot;
    public bool isWinter; 
    public float floatAlpha = 0;
    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        isHot = GameObject.Find("WorldStateManager").GetComponent<WorldState>().is_hot;
        if (this.GetComponent<Sprite>().name == "Winter")
        {
            isWinter = true; 
        }
        else if (this.GetComponent<Sprite>().name == "Summer")
        {
            isWinter = false; 
        }
        else
            Debug.Log("No Background Recognised");
    }

    //  Update is called once per frame
    void Update()
    {
        Color alpha = GetComponent<SpriteRenderer>().color;
        if (isWinter == false)
        {
            switch (isHot)
            {
                case false:
                    if (alpha.a > 0.0)
                    {
                        alpha.a -= 0.01f;
                    }
                    // GetComponent<SpriteRenderer>().color = Color.Lerp(Color.blue, Color.red, counter += Time.deltaTime);
                    break;
                case true:
                    if (alpha.a < 1)
                    {
                        alpha.a += 0.01f;
                    }
                    // GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.blue, counter += Time.deltaTime);
                    break;
            }
        }
        else
        {
            switch (isHot)
            {
                case false:
                    if (alpha.a < 1)
                    {
                        alpha.a += 0.01f;
                    }
                    // GetComponent<SpriteRenderer>().color = Color.Lerp(Color.blue, Color.red, counter += Time.deltaTime);
                    //.material.Lerp(mat1, mat2, counter += Time.deltaTime);
                    break;
                case true:
                    if (alpha.a > 0)
                    {
                        alpha.a -= 0.01f;
                    }
                    // GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.blue, counter += Time.deltaTime);
                    //.material.Lerp(mat2, mat1, counter += Time.deltaTime);
                    break;
            }
        }
        GetComponent<SpriteRenderer>().color = alpha;
        floatAlpha = alpha.a;
    }
}




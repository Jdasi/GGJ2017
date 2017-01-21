using UnityEngine;
using System.Collections;

public class BackgroundColour : MonoBehaviour
{
    public bool isWinter; 
    public float floatAlpha = 0;
    private WorldState world_state;

    // Use this for initialization
    void Start()
    {
        world_state = GameObject.Find("WorldStateManager").GetComponent<WorldState>();

        if (gameObject.name == "Winter")
        {
            isWinter = true; 
        }
        else if (gameObject.name == "Summer")
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
        if (isWinter)
        {
            switch (world_state.is_hot)
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
        }

        else
        {
            switch (world_state.is_hot)
            {
                case true:
                    if (alpha.a < 1)
                    {
                        alpha.a += 0.01f;
                    }
                    // GetComponent<SpriteRenderer>().color = Color.Lerp(Color.blue, Color.red, counter += Time.deltaTime);
                    //.material.Lerp(mat1, mat2, counter += Time.deltaTime);
                    break;
                case false:
                    if (alpha.a > 0)
                    {
                        alpha.a -= 0.01f;
                    }
                    // GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.blue, counter += Time.deltaTime);
                    //.material.Lerp(mat2, mat1, counter += Time.deltaTime);
                    break;
            }
        }

        alpha.a = Mathf.Clamp(alpha.a, 0, 1);
        GetComponent<SpriteRenderer>().color = alpha;
        floatAlpha = alpha.a;
        
    }
}




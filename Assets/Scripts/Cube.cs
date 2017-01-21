using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{

    Color temperature; 
    BoxCollider2D col;
    public bool ItColdYeh; 
    bool isCold = false; 
    // Use this for initialization
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        col.size = new Vector3(1, 1, 1) / 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        isCold = GameObject.Find("Winter").GetComponent<WinterBackground>().isCold;
        ItColdYeh = isCold;
    }
    void OnMouseEnter()
    {
        StartCoroutine(Activate()); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Activate());
    }

        IEnumerator Activate()
        {
            switch(isCold)
            {
                case true:
                temperature = Color.blue;
                    break;
                case false:
                temperature = Color.red;
                    break; 
            }
            gameObject.GetComponent<Renderer>().material.color = temperature;
            col.size = new Vector3(2, 2, 2);
            yield return new WaitForSeconds(1);
            col.size = new Vector3(1, 1, 1) / 2;
            //gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        
   
    }
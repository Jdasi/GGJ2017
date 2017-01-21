using UnityEngine;
using System.Collections;

public class CubeRipple : MonoBehaviour {

    // Use this for initialization
    public Light pointLight;
    public bool lightActive;
    private float delay;
    //private BoxCollider col;

    void Start()
    {
        pointLight.enabled = false;
        GameObject.FindGameObjectsWithTag("Cube");
        //col = gameObject.GetComponent<BoxCollider>();
    }
    void OnTriggerEnter()
    {
        StartCoroutine(activateLight());
    }
    void OnMouseOver()
    {

    }
    //set delay to 0 after everything
    //light delay function

    IEnumerator activateLight()
    {
        lightActive = true;
        pointLight.enabled = true;
        yield return new WaitForSeconds(1);
        pointLight.enabled = false;
        lightActive = false;
    }

    // Update is called once per frame
    void OnTriggerStay()
    {

    }
}


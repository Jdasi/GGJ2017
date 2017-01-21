using UnityEngine;
using System.Collections;

public class Icicle : MonoBehaviour {
    public GameObject[] icicles;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < icicles.Length; i++)
        {
            icicles[i].transform.position = new Vector2(1,0);
        }

	}
}

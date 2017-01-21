using UnityEngine;
using System.Collections;

public class JumpCheck : MonoBehaviour
{
    public bool can_jump = true;

    void Start()
    {

    }
	
	void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tile")
        {
            if (other.gameObject.GetComponent<SpriteRenderer>().enabled)
                can_jump = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tile")
            can_jump = false;
    }
}

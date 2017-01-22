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
        if (other.gameObject.tag == "Tile" || other.gameObject.tag == "Enemy")
        {
            SpriteRenderer sprite = other.gameObject.GetComponent<SpriteRenderer>();

            if (sprite)
            {
                if (sprite.enabled)
                    can_jump = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tile" || other.gameObject.tag == "Enemy")
            can_jump = false;
    }
}

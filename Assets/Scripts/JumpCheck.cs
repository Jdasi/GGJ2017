using UnityEngine;
using System.Collections;

public class JumpCheck : MonoBehaviour
{
    public bool can_jump = true;
    BoxCollider2D col;

    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
    }
	
	void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            StartCoroutine(Activate());
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tile")
            can_jump = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tile")
            can_jump = false;
    }
    IEnumerator Activate()
    {
        col.size = new Vector2(2, 10);
        yield return new WaitForSeconds(1);
        col.size = new Vector2(2, 1);
    }
}

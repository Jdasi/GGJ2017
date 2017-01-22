using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLives : MonoBehaviour
{
    public int lives = 5;
    public Vector3 last_checkpoint;

    private Text lives_display;

    void Start()
    {
        last_checkpoint = transform.position;

        lives_display = GameObject.Find("lives_display").GetComponent<Text>();
        lives_display.text = lives.ToString();
	}
	
	void Update()
    {
	
	}

    public void remove_life()
    {
        --lives;
        lives_display.text = lives.ToString();

        if (lives >= 0)
        {
            gameObject.transform.position = last_checkpoint;

            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;
        }
        else
        {
            Application.LoadLevel("Game Over");
        }
    }
}

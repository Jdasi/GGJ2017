using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


    private Animator animation;
    private bool instructionsOpen = false;
    private AudioSource audio_source;
    public AudioClip click;

    void Start()
    {
        animation = GetComponent<Animator>();
        audio_source = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        audio_source.PlayOneShot(click);

        if(!instructionsOpen)
        {
            Application.LoadLevel("Main");
        }

    }


    public void QuitGame()
    {
        audio_source.PlayOneShot(click);

        if (!instructionsOpen)
        {
            Application.Quit();
        }
    }


    public void toggleInstructions()
    {
        audio_source.PlayOneShot(click);

        instructionsOpen = !instructionsOpen;


        if (instructionsOpen)
        {
            animation.SetTrigger("Showing");
        }
        else if (!instructionsOpen)
        {
            animation.SetTrigger("Off");
        }


       
    }




}

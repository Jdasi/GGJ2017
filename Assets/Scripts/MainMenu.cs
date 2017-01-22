using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


    private Animator animation;
    private bool instructionsOpen = false;


    void Start()
    {
        animation = GetComponent<Animator>();
    }

    public void StartGame()
    {
        if(!instructionsOpen)
        {
            Application.LoadLevel("Main");
        }

    }


    public void QuitGame()
    {
        if (!instructionsOpen)
        {
            Application.Quit();
        }
    }


    public void toggleInstructions()
    {
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

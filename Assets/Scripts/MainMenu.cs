﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void StartGame()
    {
        Application.LoadLevel("Main");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}

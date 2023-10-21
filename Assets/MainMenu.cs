using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject OptionMenu;

    public void StartGame()
    {
        Debug.Log("StartGame");
    }

    public void QuitGame()
    {
        // Call the Quit method to close the game.
        Application.Quit();
    }

    public void Options()
    {
        OptionMenu.SetActive(true);
    }
}

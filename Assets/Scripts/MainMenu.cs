using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject OptionMenu;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
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
    private void Start()
    {
        OptionMenu.SetActive(false);
    }
}

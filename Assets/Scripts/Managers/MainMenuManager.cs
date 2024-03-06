using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject credits;
    public void LoadGame()
    {
        GameManager.sharedInstance.LoadGame();
    }

    public void RestartGame()
    {
        GameManager.sharedInstance.RestartGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }
}

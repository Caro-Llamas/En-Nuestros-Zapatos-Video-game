using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager sharedInstance;
    //Elementos de GUI
    public GameObject phoneUI;
    public GameObject player;
    public GameObject SavedGameText;

    FirstPersonController playerMotion;

    private void Start()
    {
        sharedInstance = this;
        playerMotion = player.GetComponent<FirstPersonController>();

        if (!GameManager.sharedInstance.hasGameBeenRestarted && GameManager.sharedInstance.sceneName == "Casa" && GameManager.sharedInstance.hasCharBeenSelected)
        {
            GameObject morningMessage = GameObject.FindGameObjectWithTag("MensajeManana");
            morningMessage.SetActive(false);
        }
        
    }

    public void OpenMenu()
    {
        phoneUI.SetActive(true);
        playerMotion.m_MouseLook.SetCursorLock(false);
    } 

    public void CloseMenu()
    {
        SavedGameText.SetActive(false);
        phoneUI.SetActive(false);

        playerMotion.m_MouseLook.SetCursorLock(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveGame()
    {
        GameManager.sharedInstance.SaveGame();
        SavedGameText.SetActive(true);
    }

    
}

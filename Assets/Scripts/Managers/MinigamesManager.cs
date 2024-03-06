using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigamesManager : MonoBehaviour
{
    [SerializeField] private GameObject phoneUI;
    [SerializeField] private GameObject equipo;
    [SerializeField] private GameObject esquivando;
    [SerializeField] private GameObject revienta;
    [SerializeField] private GameObject player;

    private FirstPersonController playerMotion;

    public bool[] minigameStarted = { false, false, false };

    private Scene currentScene;
    private string sceneName;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        phoneUI.SetActive(false);
        equipo.SetActive(false);
        esquivando.SetActive(false);
        revienta.SetActive(false);
        playerMotion = player.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sceneName)
        {
            case "Camion":
                if (GameManager.sharedInstance.hasSituationEnded[2] && !GameManager.sharedInstance.minigameActivated[3])
                {
                    GameManager.sharedInstance.minigameActivated[3] = true;
                    if (!minigameStarted[0])
                    {
                        revienta.SetActive(true);
                        phoneUI.SetActive(true);
                        StopPlayer();
                        minigameStarted[0] = true;
                    }
                }
                break;

            case "Casa":
                if (SelectCharacter.hasCharacterBeenSelected && !GameManager.sharedInstance.minigameActivated[0])
                {
                    GameManager.sharedInstance.minigameActivated[0] = true;
                    if (!minigameStarted[0])
                    {
                        revienta.SetActive(true);
                        phoneUI.SetActive(true);
                        StopPlayer();
                        minigameStarted[0] = true;

                    }
                }

                if (GameManager.sharedInstance.hasSituationEnded[0] && !GameManager.sharedInstance.minigameActivated[1])
                {
                    GameManager.sharedInstance.minigameActivated[1] = true;
                    if (!minigameStarted[1])
                    {
                        minigameStarted[1] = true;
                        esquivando.SetActive(true);
                        phoneUI.SetActive(true);
                        StopPlayer();
                        EsquivandoManager.sharedInstance.RestartGame();
                    }
                }

                if (GameManager.sharedInstance.hasSituationEnded[9] && !GameManager.sharedInstance.minigameActivated[5])
                {
                    GameManager.sharedInstance.minigameActivated[5] = true;
                    if (!minigameStarted[2])
                    {
                        minigameStarted[2] = true;
                        equipo.SetActive(true);
                        phoneUI.SetActive(true);
                        StopPlayer();
                    }
                }
                break;

            case "Salon":
                if (GameManager.sharedInstance.hasSituationEnded[4] && !GameManager.sharedInstance.minigameActivated[4])
                {
                    GameManager.sharedInstance.minigameActivated[4] = true;
                    if (!minigameStarted[1])
                    {
                        minigameStarted[1] = true;
                        esquivando.SetActive(true);
                        phoneUI.SetActive(true);
                        StopPlayer();
                        EsquivandoManager.sharedInstance.RestartGame();
                    }
                }
                break;

            case "TerrenoPrincipal":
                if (GameManager.sharedInstance.hasSituationEnded[1] && !GameManager.sharedInstance.minigameActivated[2])
                {
                    GameManager.sharedInstance.minigameActivated[2] = true;
                    if (!minigameStarted[0])
                    {
                        revienta.SetActive(true);
                        phoneUI.SetActive(true);
                        StopPlayer();
                        minigameStarted[0] = true;
                    }
                }
                break;
        }
        
    }

    public static bool gameClosed = false;

    public void ExitMinigame()
    {
        if (sceneName == "Salon") gameClosed = true;

        phoneUI.SetActive(false);
        equipo.SetActive(false);
        esquivando.SetActive(false);
        revienta.SetActive(false);
        MovePlayer();
    }

    private void StopPlayer()
    {
        playerMotion.m_WalkSpeed = 0;
        playerMotion.m_RunSpeed = 0;
        playerMotion.m_MouseLook.MaximumX = 0;
        playerMotion.m_MouseLook.MinimumX = 0;

        playerMotion.m_MouseLook.SetCursorLock(false);
    }

    private void MovePlayer()
    {
        switch (sceneName)
        {
            case "Camion":
                playerMotion.m_WalkSpeed = 2;
                playerMotion.m_RunSpeed = 3;
                break;

            case "Casa":
                playerMotion.m_WalkSpeed = 2;
                playerMotion.m_RunSpeed = 4;
                break;

            case "Salon":
                playerMotion.m_WalkSpeed = 5;
                playerMotion.m_RunSpeed = 7;
                break;

            case "TerrenoPrincipal":
                playerMotion.m_WalkSpeed = 5;
                playerMotion.m_RunSpeed = 7;
                break;
        }
        
        playerMotion.m_MouseLook.MaximumX = 90;
        playerMotion.m_MouseLook.MinimumX = -70;

        playerMotion.m_MouseLook.SetCursorLock(true);
    }
}

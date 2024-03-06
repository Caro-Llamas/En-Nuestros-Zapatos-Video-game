using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    public bool[] hasSituationEnded;
    public bool[] typeOfSpawn = new bool[4]; // 0 - CasaAfuera, 1 - ParadaEscuela, 2 - Pasillo, 3 - ParadaColonia, 
    public bool[] minigameActivated = new bool[6];

    public Transform player;
    public Vector3 playerPos;

    public string characterSelected;
    public bool hasCharBeenSelected;

    private Scene actualScene;
    public string sceneName;

    public bool hasGameBeenLoaded = false;
    public bool hasGameBeenRestarted = false;

    public bool isGameOnMainMenu = false;
    public bool isGameOnFinal = false;
    public bool terrainTrigger = false;

    GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        GetActualScene();

        if(sceneName == "MainMenu") isGameOnMainMenu = true;
        if (sceneName != "FinalScene") isGameOnFinal = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetActualScene();
        if (sceneName != "MainMenu") isGameOnMainMenu = false;
        if (sceneName == "FinalScene") isGameOnFinal = true;

        

        if (!isGameOnMainMenu && !isGameOnFinal)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager.sharedInstance.OpenMenu();
            }

            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
                if (hasGameBeenLoaded)
                {

                    //player.GetComponent<FirstPersonController>().enabled = false;
                    playerPos = new Vector3(gameData.position[0], gameData.position[1], gameData.position[2]);

                    characterSelected = gameData.selectedChar;
                    hasCharBeenSelected = gameData.hasCharBeenSelected;

                    for (int i = 0; i < 11; i++)
                    {
                        hasSituationEnded[i] = gameData.hasSituationEnded[i];
                    }

                    for (int y = 0; y < 6; y++)
                    {
                        minigameActivated[y] = gameData.minigamesStatus[y];
                    }
                    
                    player.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
                    Invoke(nameof(ActivePlayerMovement), 2.0f);
                    hasGameBeenLoaded = false;
                }
            }
            CheckSituationsStatus();
        }
        
    }

    public void SaveGame()
    {
        SaveManager.SaveGameData(this);
    }

    public void LoadGame()
    {
        hasGameBeenLoaded = true;
        gameData = SaveManager.LoadGameData();
        SceneManager.LoadScene(gameData.actualScene);
        isGameOnMainMenu = false;
        

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Casa");
        hasGameBeenRestarted = true;

        SaveManager.DeleteAllData();
    }

    
    public void ActivePlayerMovement()
    {
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    private void CheckSituationsStatus()
    {
        //Situaciones de la casa
        SelectCharacter.hasCharacterBeenSelected = hasCharBeenSelected;
        Situation1Behaviour.hasEnded = hasSituationEnded[0];
        Situation10Behaviour.hasEnded = hasSituationEnded[9];
        Situation11Behaviour.hasEnded = hasSituationEnded[10];

        //Situaciones del terreno
        Situation2Behaviour.hasEnded = hasSituationEnded[1];
        Situation7Behaviour.hasEnded = hasSituationEnded[6];
        Situation9Behaviour.hasEnded = hasSituationEnded[8];

        //Situaciones del camion
        Situation3Behaviour.hasEnded = hasSituationEnded[2];
        Situation8Behaviour.hasEnded = hasSituationEnded[7];

        //Situaciones del salon
        Situation4Behaviour.hasEnded = hasSituationEnded[3];
        Situation5Behaviour.hasEnded = hasSituationEnded[4];
        Situation6Behaviour.hasEnded = hasSituationEnded[5];
    }

    public void GetActualScene()
    {
        actualScene = SceneManager.GetActiveScene();
        sceneName = actualScene.name;
    }
}

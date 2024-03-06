using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Scene activeScene;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        sceneName = activeScene.name;

        switch (sceneName)
        {
            case "Camion":
                player.transform.position = GameObject.FindGameObjectWithTag("SpawnCamion").transform.position;
                Invoke(nameof(ActivePlayerMovement), 1.0f);
                break;

            case "Casa":
                if (SelectCharacter.hasCharacterBeenSelected)
                {
                    player.transform.position = GameObject.FindGameObjectWithTag("SpawnCasa").transform.position;
                    Invoke(nameof(ActivePlayerMovement), 1.0f);
                }
                
                break;

            case "Salon":
                player.transform.position = GameObject.FindGameObjectWithTag("SpawnSalon").transform.position;
                Invoke(nameof(ActivePlayerMovement), 1.0f);
                break;

            case "TerrenoPrincipal":
                if (GameManager.sharedInstance.typeOfSpawn[0])
                {
                    player.transform.position = GameObject.FindGameObjectWithTag("SpawnCasaAfuera").transform.position;
                    GameManager.sharedInstance.typeOfSpawn[0] = false;
                    Invoke(nameof(ActivePlayerMovement), 1.0f);
                }
                else if (GameManager.sharedInstance.typeOfSpawn[1])
                {
                    
                    player.transform.position = GameObject.FindGameObjectWithTag("SpawnParadaEsc").transform.position;
                    GameManager.sharedInstance.typeOfSpawn[1] = false;
                    Invoke(nameof(ActivePlayerMovement), 1.0f);
                }
                else if (GameManager.sharedInstance.typeOfSpawn[2])
                {
                    player.transform.position = GameObject.FindGameObjectWithTag("SpawnEdificioEscuela").transform.position;
                    GameManager.sharedInstance.typeOfSpawn[2] = false;
                    Invoke(nameof(ActivePlayerMovement), 1.0f);
                }
                else if (GameManager.sharedInstance.typeOfSpawn[3])
                {
                    player.transform.position = GameObject.FindGameObjectWithTag("SpawnParadaCol").transform.position;
                    GameManager.sharedInstance.typeOfSpawn[3] = false;
                    Invoke(nameof(ActivePlayerMovement), 0.1f);
                }
                break;
        }
        Invoke(nameof(ActivePlayerMovement), 1.0f);

    }

    public void ActivePlayerMovement()
    {
        player.GetComponent<FirstPersonController>().enabled = true;
    }
}

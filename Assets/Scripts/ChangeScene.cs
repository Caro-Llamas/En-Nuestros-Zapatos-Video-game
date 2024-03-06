using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneToChange;
    public GameObject actionMark;

    private Scene activeScene;
    private string sceneName;

    private bool isPlayerInRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        sceneName = activeScene.name;
        actionMark.SetActive(false);

    }

    private void Update()
    {
        ChangeScenes();
        SetTerrainTrigger();
    }

    private void ChangeScenes()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
        {
            if (sceneToChange == "Casa")
            {
                SceneManager.LoadScene(sceneToChange);
            }
            else if (sceneToChange == "TerrenoPrincipal")
            {
                SceneManager.LoadScene(sceneToChange);
            }
            else if (sceneToChange == "Camion")
            {
                SceneManager.LoadScene(sceneToChange);
            }
            else if (sceneToChange == "Salon")
            {
                SceneManager.LoadScene(sceneToChange);
            }
        }
    }

    private void SetTerrainTrigger()
    {
        if (GameManager.sharedInstance.hasSituationEnded[7] && !GameManager.sharedInstance.terrainTrigger)
        {
            GameManager.sharedInstance.terrainTrigger = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (sceneName)
            {
                case "Camion":
                    if (GameManager.sharedInstance.hasSituationEnded[0] && !GameManager.sharedInstance.terrainTrigger)
                    {
                        GameManager.sharedInstance.terrainTrigger = true;
                        GameManager.sharedInstance.typeOfSpawn[1] = true;
                    }
                    else if (GameManager.sharedInstance.hasSituationEnded[7] && GameManager.sharedInstance.terrainTrigger)
                    {
                        GameManager.sharedInstance.typeOfSpawn[3] = true;
                    }

                    break;

                case "Casa":
                    GameManager.sharedInstance.typeOfSpawn[0] = true;
                    break;

                case "Salon":
                    GameManager.sharedInstance.typeOfSpawn[2] = true;
                    break;
            }

            actionMark.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            actionMark.SetActive(false);
            isPlayerInRange = false;
        }
    }
}

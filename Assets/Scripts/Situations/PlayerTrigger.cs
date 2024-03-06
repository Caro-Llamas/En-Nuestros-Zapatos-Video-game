using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    public static bool hasTriggerCollider = false;

    private Scene currentScene;
    private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasTriggerCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (other.gameObject.CompareTag("Player") && sceneName == "Camion")
        {
            hasTriggerCollider = false;
            GameManager.sharedInstance.hasSituationEnded[2] = true;
        }
    }
}

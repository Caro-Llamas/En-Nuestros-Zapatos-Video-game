 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SituationsManager : MonoBehaviour
{
    public static SituationsManager sharedInstance;

    private Scene currentScene;
    private string sceneName;

    [SerializeField] private GameObject[] situations;

    private GameObject partyPjs;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        switch (sceneName)
        {
            case "Camion":
                AsignCamionSituations();
                break;

            case "Casa":
                AsignCasaSituations();

                partyPjs = GameObject.FindGameObjectWithTag("PartyPjs");

                break;

            case "Salon":
                AsignSalonSituations();
                break;

            case "TerrenoPrincipal":
                AsignTerrenoSituations();
                break;
        }
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        switch (sceneName)
        {
            case "TerrenoPrincipal":
                //Cambiando si esta activo o no el game object de las situaciones
                ChangeSituationsStatusTerreno();
                break;

            case "Camion":

                //Cambiando si esta activo o no el game object de las situaciones
                ChangeSituationsStatusCamion();
                break;

            case "Salon":
                //Cambiando si esta activo o no el game object de las situaciones
                ChangeSituationsStatusSalon();
                break;

            case "Casa":
                //Cambiando si esta activo o no el game object de las situaciones
                ChangeSituationsStatusCasa();

                ShowOrHidePartyPjs(partyPjs);
                break;
        }
    }

    private void ShowOrHidePartyPjs(GameObject partyPjs)
    {
        if (GameManager.sharedInstance.hasSituationEnded[8])
        {
            partyPjs.SetActive(true);
        }
        else
        {
            partyPjs.SetActive(false);
        }
    }

    //Asignando situaciones al array
    private void AsignCasaSituations()
    {
        situations[0] = GameObject.Find("SituacionViolenta1");
        situations[1] = GameObject.Find("SituacionViolenta10");
        situations[2] = GameObject.Find("SituacionViolenta11");

        situations[0].SetActive(false); //1
        situations[1].SetActive(false); //10
        situations[2].SetActive(false); //11
    }

    private void AsignTerrenoSituations()
    {
        situations[0] = GameObject.Find("SituacionViolenta2");
        situations[1] = GameObject.Find("SituacionViolenta7");
        situations[2] = GameObject.Find("SituacionViolenta9");

        situations[0].SetActive(false); //2
        situations[1].SetActive(false); //7
        situations[2].SetActive(false); //9
    }

    private void AsignCamionSituations()
    {
        situations[0] = GameObject.Find("SituacionViolenta3");
        situations[1] = GameObject.Find("SituacionViolenta8");
        
        situations[0].SetActive(false); //3
        situations[1].SetActive(false); //8
    }

    private void AsignSalonSituations()
    {
        situations[0] = GameObject.Find("SituacionViolenta4");
        situations[1] = GameObject.Find("SituacionViolenta5");
        situations[2] = GameObject.Find("SituacionViolenta6");

        situations[0].SetActive(false); //4
        situations[1].SetActive(false); //5
        situations[2].SetActive(false); //6
    }

    //Cambiando si esta activo o no la situacion en orden del guion
    private void ChangeSituationsStatusCasa()
    {
        if (!SelectCharacter.isPlayerInRange && SelectCharacter.hasCharacterBeenSelected)
        {
            situations[0].SetActive(true);
        }

        if (GameManager.sharedInstance.hasSituationEnded[0])
        {
            situations[0].SetActive(false);
        }

        if (GameManager.sharedInstance.hasSituationEnded[8])
        {
            situations[1].SetActive(true);
        }

        if (GameManager.sharedInstance.hasSituationEnded[9])
        {
            situations[1].SetActive(false);
            situations[2].SetActive(true);
        }

        

    }

    private void ChangeSituationsStatusTerreno()
    {
        if (GameManager.sharedInstance.hasSituationEnded[0])
        {
            situations[0].SetActive(true); //Activando la situacion 2 si ya termino la 1
        }
        
        if(GameManager.sharedInstance.hasSituationEnded[1])
        {
            situations[0].SetActive(false); //desactivando la situacion 2 porque ya termino
        }

        if (GameManager.sharedInstance.hasSituationEnded[5])
        {
            situations[1].SetActive(true); //Activando la situacion violenta 7 xq termino la 6
        }
        
        if(GameManager.sharedInstance.hasSituationEnded[6])
        {
            situations[1].SetActive(false); //desactivando la situacion violenta 7  porque ya termino
        }

        if (GameManager.sharedInstance.hasSituationEnded[7])
        {
            situations[2].SetActive(true); //Activando la situacion violenta 9 si ya termino la 8
        }
        
        if(GameManager.sharedInstance.hasSituationEnded[8])
        {
            situations[2].SetActive(false); //desactivando la situacion violenta 9 porque ya termino
        }
    }

    private void ChangeSituationsStatusCamion()
    {
        //Activando la situación 3 si ya termino la situación 2 y esta sentado el jugador
        if (GameManager.sharedInstance.hasSituationEnded[1])
        {
            situations[0].SetActive(true);
        }

        //Desactivando la situación 3 porque ya termino
        if (GameManager.sharedInstance.hasSituationEnded[2])
        {
            situations[0].SetActive(false);
        }

        //Activando la situación 8 si ya termino la situación 7
        if (GameManager.sharedInstance.hasSituationEnded[6])
        {
            situations[1].SetActive(true);
        }

        //Desactivando la situación 8 porque ya termino
        if (GameManager.sharedInstance.hasSituationEnded[7])
        {
            situations[1].SetActive(false);
        }
    }

    private void ChangeSituationsStatusSalon()
    {
        if (PlayerAnimatorController.sharedInstance.m_isSit && GameManager.sharedInstance.hasSituationEnded[2])
        {
            situations[0].SetActive(true); //Activando la situacion 4 si ya termino la 3
        }

        if (GameManager.sharedInstance.hasSituationEnded[3])
        {
            situations[0].SetActive(false); //Desactivando la situacion violenta 4
            situations[1].SetActive(true); //Activando la situacion violenta 5
        }

        if (GameManager.sharedInstance.hasSituationEnded[4] && MinigamesManager.gameClosed)
        {
            situations[1].SetActive(false); //Desactivando la situacion violenta 5
            situations[2].SetActive(true); //Activando la situacion violenta 6
        }
        else
        {
            situations[2].SetActive(false); //desactivando la situacion violenta 6 porque ya terminaron todas
        }
    }
}

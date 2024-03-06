using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAsigner : MonoBehaviour
{
    public GameObject[] models = new GameObject[6];

    private bool oneTimeUse = true;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.sharedInstance.characterSelected)
        {
            case "playerF1":
                models[0].SetActive(true);
                break;

            case "playerF2":
                models[1].SetActive(true);
                break;

            case "playerF3":
                models[2].SetActive(true);
                break;

            case "playerM1":
                models[3].SetActive(true);
                break;

            case "playerM2":
                models[4].SetActive(true);
                break;

            case "playerM3":
                models[5].SetActive(true);
                break;
        }
        
    }

    private void Update()
    {
        if (GameManager.sharedInstance.hasCharBeenSelected && oneTimeUse)
        {
            oneTimeUse = false;
            switch (GameManager.sharedInstance.characterSelected)
            {
                case "playerF1":
                    models[0].SetActive(true);
                    break;

                case "playerF2":
                    models[1].SetActive(true);
                    break;

                case "playerF3":
                    models[2].SetActive(true);
                    break;

                case "playerM1":
                    models[3].SetActive(true);
                    break;

                case "playerM2":
                    models[4].SetActive(true);
                    break;

                case "playerM3":
                    models[5].SetActive(true);
                    break;
            }
        }
    }

}

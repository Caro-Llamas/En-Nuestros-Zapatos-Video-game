using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectCharUI : MonoBehaviour
{
    public static SelectCharUI sharedInstance;

    [SerializeField] private GameObject SelectCharPanel;
    [SerializeField] private GameObject[] halos;

    
    // Start is called before the first frame update
    void Awake()
    {
        sharedInstance = this;
    }

    public void CloseSelectChars()
    {
        SelectCharPanel.SetActive(false);
        GameManager.sharedInstance.hasCharBeenSelected = true;
    }

    public void ChangeHaloPlace()
    {
        switch (GameManager.sharedInstance.characterSelected)
        {
            case "playerF1":
                halos[0].SetActive(true);
                halos[1].SetActive(false);
                halos[2].SetActive(false);
                halos[3].SetActive(false);
                halos[4].SetActive(false);
                halos[5].SetActive(false);
                break;

            case "playerF2":
                halos[0].SetActive(false);
                halos[1].SetActive(true);
                halos[2].SetActive(false);
                halos[3].SetActive(false);
                halos[4].SetActive(false);
                halos[5].SetActive(false);
                break;

            case "playerF3":
                halos[0].SetActive(false);
                halos[1].SetActive(false);
                halos[2].SetActive(true);
                halos[3].SetActive(false);
                halos[4].SetActive(false);
                halos[5].SetActive(false);
                break;

            case "playerM1":
                halos[0].SetActive(false);
                halos[1].SetActive(false);
                halos[2].SetActive(false);
                halos[3].SetActive(true);
                halos[4].SetActive(false);
                halos[5].SetActive(false);
                break;

            case "playerM2":
                halos[0].SetActive(false);
                halos[1].SetActive(false);
                halos[2].SetActive(false);
                halos[3].SetActive(false);
                halos[4].SetActive(true);
                halos[5].SetActive(false);
                break;

            case "playerM3":
                halos[0].SetActive(false);
                halos[1].SetActive(false);
                halos[2].SetActive(false);
                halos[3].SetActive(false);
                halos[4].SetActive(false);
                halos[5].SetActive(true);
                break;

        }
    }
}

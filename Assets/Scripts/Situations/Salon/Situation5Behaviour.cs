using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation5Behaviour : MonoBehaviour
{
    public static bool hasEnded = false;

    public static bool startDialogue = false;

    [SerializeField] private GameObject phoneScreen;

    //variables varias
    private int _closeAndOpen = 1;

    //private void Awake()
    //{
    //    hasEnded = GameManager.sharedInstance.hasSituationEnded[4];
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(_closeAndOpen == 1)
            {
                phoneScreen.SetActive(true);
                _closeAndOpen = 2;
            }
            else if(_closeAndOpen == 2)
            {
                phoneScreen.SetActive(false);
                _closeAndOpen = 1;
                GameManager.sharedInstance.hasSituationEnded[4] = true;
            }
            
        }
    }
}

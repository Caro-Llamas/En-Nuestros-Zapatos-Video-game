using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation8Behaviour : MonoBehaviour
{
    public static bool hasEnded;

    [SerializeField] private GameObject extraPanel;
    [SerializeField] private GameObject phoneScreen;

    //variables varias
    private int _closeAndOpen = 1;
    private bool _notificationTrigger = true;

    public GameObject extraDialogueSit3;

    private void Awake()
    {
        if (GameManager.sharedInstance.hasSituationEnded[2]) extraDialogueSit3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAnimatorController.sharedInstance.m_isSit && _notificationTrigger)
        {
            extraPanel.SetActive(true);
            _notificationTrigger = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            extraPanel.SetActive(false);
            if (_closeAndOpen == 1)
            {
                phoneScreen.SetActive(true);
                _closeAndOpen = 2;
            }
            else if (_closeAndOpen == 2)
            {
                phoneScreen.SetActive(false);
                Dialogue.forceDialogue = true;
                _closeAndOpen = 1;
                
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.sharedInstance.hasSituationEnded[7] = true;
        }
    }
}

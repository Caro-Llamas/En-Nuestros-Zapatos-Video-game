using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation7Behaviour : MonoBehaviour
{
    public static bool hasEnded;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject phoneScreen;
    [SerializeField] private GameObject extraPanel;
    [SerializeField] private GameObject notificationMark;

    private int _closeAndOpen = 1;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_closeAndOpen == 1)
            {
                
                phoneScreen.SetActive(true);
                extraPanel.SetActive(true);
                _closeAndOpen = 2;
            }
            else if (_closeAndOpen == 2)
            {
                phoneScreen.SetActive(false);
                extraPanel.SetActive(false);
                MovePlayer();
                _closeAndOpen = 1;
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopPlayer();
            notificationMark.SetActive(true);
            Dialogue.forceDialogue = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            notificationMark.SetActive(false);
            GameManager.sharedInstance.hasSituationEnded[6] = true;
        }
    }

    private void StopPlayer()
    {
        player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
        player.GetComponent<FirstPersonController>().m_RunSpeed = 0;

    }

    private void MovePlayer()
    {
        player.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
        player.GetComponent<FirstPersonController>().m_RunSpeed = 7;

    }
}
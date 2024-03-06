using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation1Behaviour : MonoBehaviour
{
    public static bool hasEnded; 

    [SerializeField] private Transform playerGameObject;
    [SerializeField] private Transform momGameObject;

    public GameObject exitZone;
    public bool isPlayerInRange = false;

    [SerializeField] private int animationsOrder = 0;
    // Start is called before the first frame update

    //private void Awake()
    //{
    //    hasEnded = GameManager.sharedInstance.hasSituationEnded[0];
    //}

    // Update is called once per frame
    void Update()
    {
        if (/*Situacion*/!hasEnded)
        {
            if (Input.GetKeyDown(KeyCode.E) && Dialogue.didDialogueStarted)
            {
                ChangeMomAnimation();
                if (animationsOrder == 2)
                {
                    animationsOrder = 2;
                }
                else
                {
                    animationsOrder++;
                }
            }

            if (isPlayerInRange)
            {
                MomLookAtPlayer();
            }

        }


    }

    private void ChangeMomAnimation()
    {
        animationsOrder = Dialogue.lineIndex;
        switch (animationsOrder)
        {
            case 0:
                MomAnimatorController.sharedInstance.m_isDisapproving = true;
                MomAnimatorController.sharedInstance.m_isIdle = false;
                break;

            case 1:
                MomAnimatorController.sharedInstance.m_isComplaining = true;
                MomAnimatorController.sharedInstance.m_isDisapproving = false;
                break;

            case 2:
                MomAnimatorController.sharedInstance.m_isIdle = true;
                MomAnimatorController.sharedInstance.m_isComplaining = false;
                break;
        }

    }

    private void MomLookAtPlayer()
    {
        
        momGameObject.LookAt(new Vector3(playerGameObject.position.x,
                                            transform.position.y,
                                            playerGameObject.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            GameManager.sharedInstance.hasSituationEnded[0] = true;
            exitZone.SetActive(true);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation4Behaviour : MonoBehaviour
{
    public static bool hasEnded;

    [SerializeField] private Transform playerTrans;

    [SerializeField] private GameObject acosador;
    private MoveToWaypoints acosadorMotion;
    private AcosadorAnimatorController acosadorAnimator;
    [SerializeField] private float acosSpeed;

    private int animationsOrder = 0;
    public bool moveAcos = true;

    private void Start()
    {
        Waypoint.isAcosOnWaypoint = false;
        acosadorMotion = acosador.GetComponent<MoveToWaypoints>();
        acosadorAnimator = acosador.GetComponent<AcosadorAnimatorController>();

        if (acosadorMotion.isStatic)
        {
            acosadorAnimator.m_isWalking = false;
            acosadorAnimator.m_isLean = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveAcosador();
        ChangeAcosadorAnimations();

    }

    private void MoveAcosador()
    {
        if (PlayerAnimatorController.sharedInstance.m_isSit)
        {
            if (moveAcos)
            {
                MoveToWaypoints.sharedInstance.speed = acosSpeed;
                
                acosadorMotion.isStatic = false;

                acosadorAnimator.m_isWalking = true;
                acosadorAnimator.m_isLean = false;
                moveAcos = false;
            } 
        }
    }

    private bool acosLeaving = true;

    private void ChangeAcosadorAnimations()
    {
        
        if(Dialogue.lineIndex == Dialogue.dialogueLinesLenght && !Dialogue.didDialogueStarted)
        {
            acosadorMotion.isStatic = false;
            if (acosLeaving)
            {
                acosadorMotion.targetToLook = GameObject.Find("AcWp3").transform;
                acosadorMotion.transform.LookAt(new Vector3(acosadorMotion.targetToLook.position.x,
                                                            acosadorMotion.transform.position.y,
                                                            acosadorMotion.targetToLook.position.z));
                acosLeaving = false;
                //Situacion 4 ha terminado
                GameManager.sharedInstance.hasSituationEnded[3] = true;
            }

            acosadorMotion.speed = acosSpeed;
            Waypoint.isAcosOnWaypoint = false;

            acosadorAnimator.m_isTalking = false;
            acosadorAnimator.m_isWalking = true;
        }

        if (Waypoint.isAcosOnWaypoint)
        {
            acosadorMotion.isStatic = true;
            acosadorMotion.speed = 0;

            animationsOrder = Dialogue.lineIndex;

            switch (animationsOrder)
            {
                case 0:
                    acosadorAnimator.m_isWalking = false;
                    acosadorAnimator.m_isTalking = true;
                    break;

                case 4:
                    acosadorAnimator.m_isTalking = false;
                    acosadorAnimator.m_isSayNo = true;
                    break;

                case 5:
                    acosadorAnimator.m_isTalking = true;
                    acosadorAnimator.m_isSayNo = false;
                    break;

                case 8:
                    acosadorAnimator.m_isTalking = false;
                    acosadorAnimator.m_isYelling = true;
                    break;

                case 13:
                    
                    acosadorAnimator.m_isYelling = false;
                    break;
            }

            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            Debug.Log(Waypoint.isAcosOnWaypoint);
        }
    }


}

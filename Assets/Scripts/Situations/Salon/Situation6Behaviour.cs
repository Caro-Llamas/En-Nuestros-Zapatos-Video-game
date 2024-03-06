using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Situation6Behaviour : MonoBehaviour
{
    public static bool hasEnded;

    [SerializeField] private GameObject professor;
    private ProfessorAnimatorController profAnimator;
    private MoveToWaypoints profMotion;

    private bool profCanAppear = true;
    [SerializeField] private int animationsOrder = 0;

    //private void Awake()
    //{
    //    hasEnded = GameManager.sharedInstance.hasSituationEnded[5];
    //}

    // Start is called before the first frame update
    void Start()
    {
        profAnimator = professor.GetComponent<ProfessorAnimatorController>();
        profMotion = professor.GetComponent<MoveToWaypoints>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.hasSituationEnded[4])
        {
            if (profCanAppear)
            {
                professor.SetActive(true);
                profCanAppear = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && Dialogue.didDialogueStarted)
        {
            ChangeAnimations();
            if (animationsOrder == 2)
            {
                animationsOrder = 2;
                GameManager.sharedInstance.hasSituationEnded[5] = true;
            }
            else
            {
                animationsOrder++;
            }
        }
    }


    private void ChangeAnimations()
    {
        animationsOrder = Dialogue.lineIndex;
        if (Dialogue.didDialogueStarted)
        {
            switch (animationsOrder)
            {
                case 0:
                    profAnimator.m_isIdle = false;
                    profAnimator.m_isTalking = true;
                    break;

                case 1:
                    profAnimator.m_isIdle = false;
                    profAnimator.m_isTalking = false;
                    profAnimator.m_isDeniyng = true;
                    break;

                case 2:
                    profAnimator.m_isIdle = false;
                    profAnimator.m_isDeniyng = false;
                    profAnimator.m_isLaughing = true;
                    break;
            }
            
        }

    }
}

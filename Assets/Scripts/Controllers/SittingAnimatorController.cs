using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingAnimatorController : MonoBehaviour
{
    [SerializeField] private int m_Type = 0;
    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();

        switch (m_Type)
        {
            case 0: //Idle Animation (Starter Animation)
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 1: //Sitting Idle 1 Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 2: //Sitting Idle 2 Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 3: //Stand To Sit Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 4: //Sit To Stand Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 5: //Dissapointed Sitting Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 6: //Sit And Point Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 7: //Sit Moving Leg Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 8: //Dissaproving Sitting Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 9: //Sitting Laughing Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 10: //Sitting Looking Around Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 11: //Sitting Crossing Legs Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 12: //Sitting Talking Left Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 13: //Sitting Talking Right Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 14: //Sitting Thumbs Up Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 15: //Sit Yelling Animation
                m_Animator.SetInteger("Type", m_Type);
                break;
        }
    }
}

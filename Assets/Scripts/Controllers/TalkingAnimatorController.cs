using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingAnimatorController : MonoBehaviour
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

            case 1: //Default Talking Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 2: //Talking on Phone Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 3: //Talking Saying No Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

            case 4: //Yelling Animation
                m_Animator.SetInteger("Type", m_Type);
                break;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpersAnimatorController : MonoBehaviour
{
    [SerializeField] public int m_Type = 0;
    [SerializeField] public bool m_IsIdle = true;
    [SerializeField] public bool m_IsStanding = false;
    [SerializeField] public bool m_IsYelling = false;
    [SerializeField] public bool m_IsSit = false;
    [SerializeField] public bool m_IsWalking = false;
    [SerializeField] public bool m_IsTalking = false;

    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Type == 1)
        {
            m_Animator.SetInteger("TypeOfSit", m_Type); // talking right animation
        }
        else if(m_Type == 2)
        {
            m_Animator.SetInteger("TypeOfSit", m_Type); //talking left animation
        }

        if(m_Type == 0)
        {
            m_Animator.SetInteger("TypeOfSit", m_Type); //No sit talking animation
        }

        //Walking animation states
        if (m_IsWalking)
        {
            m_Animator.SetBool("IsWalking", true);
        }
        else
        {
            m_Animator.SetBool("IsWalking", false);
        }

        //Talking animation states
        if (m_IsTalking)
        {
            m_Animator.SetBool("IsTalking", true);
        }
        else
        {
            m_Animator.SetBool("IsTalking", false);
        }

        //Sitting Animation States
        if (m_IsSit)
        {
            m_Animator.SetBool("IsSit", true);
        }
        else
        {
            m_Animator.SetBool("IsSit", false);
        }

        //Idle Animation states
        if (m_IsIdle)
        {
            m_Animator.SetBool("IsIdle", true);
        }
        else
        {
            m_Animator.SetBool("IsIdle", false);
        }

        //Yelling animation states
        if (m_IsYelling)
        {
            m_Animator.SetBool("IsYelling", true);
        }
        else
        {
            m_Animator.SetBool("IsYelling", false);
        }

        //Leaning animation states
        if (m_IsStanding)
        {
            m_Animator.SetBool("IsStanding", true);
        }
        else
        {
            m_Animator.SetBool("IsStanding", false);
        }
    }
}

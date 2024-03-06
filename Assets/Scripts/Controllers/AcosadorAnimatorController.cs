using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcosadorAnimatorController : MonoBehaviour
{
    public bool m_isWalking = false;
    public bool m_isSit = false;
    public bool m_isTalking = false;
    public bool m_isLean = true;
    public bool m_isHarassing = false;
    public bool m_isSayNo = true;
    public bool m_isYelling = false;
    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walking animation states
        if (m_isWalking)
        {
            m_Animator.SetBool("IsWalking", true);
        }
        else
        {
            m_Animator.SetBool("IsWalking", false);
        }

        //Sitting Animation States
        if (m_isSit)
        {
            m_Animator.SetBool("IsSit", true);
        }
        else
        {
            m_Animator.SetBool("IsSit", false);
        }

        //Talking Animation states
        if (m_isTalking)
        {
            m_Animator.SetBool("IsTalking", true);
        }
        else
        {
            m_Animator.SetBool("IsTalking", false);
        }

        //Harassing animation states
        if (m_isHarassing)
        {
            m_Animator.SetBool("IsHarassing", true);
        }
        else
        {
            m_Animator.SetBool("IsHarassing", false);
        }

        //Leaning animation states
        if (m_isLean)
        {
            m_Animator.SetBool("IsLean", true);
        }
        else
        {
            m_Animator.SetBool("IsLean", false);
        }

        //Leaning animation states
        if (m_isSayNo)
        {
            m_Animator.SetBool("isSayNo", true);
        }
        else
        {
            m_Animator.SetBool("isSayNo", false);
        }

        //Leaning animation states
        if (m_isYelling)
        {
            m_Animator.SetBool("isYelling", true);
        }
        else
        {
            m_Animator.SetBool("isYelling", false);
        }

    }
}

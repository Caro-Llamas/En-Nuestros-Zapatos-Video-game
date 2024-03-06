using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorAnimatorController : MonoBehaviour
{
    public bool m_isWalking = false;
    public bool m_isLaughing = false;
    public bool m_isIdle = true;
    public bool m_isTalking = false;
    public bool m_isDeniyng = false;
    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeParametersOnAnimator();
    }

    private void ChangeParametersOnAnimator()
    {
        //Walking parameter
        if (m_isWalking)
        {
            m_Animator.SetBool("isWalking", true);
        }
        else
        {
            m_Animator.SetBool("isWalking", false);
        }

        //Laughing parameter
        if (m_isLaughing)
        {
            m_Animator.SetBool("isLaughing", true);
        }
        else
        {
            m_Animator.SetBool("isLaughing", false);
        }

        //Denying parameter
        if (m_isDeniyng)
        {
            m_Animator.SetBool("isDeniyng", true);
        }
        else
        {
            m_Animator.SetBool("isDeniyng", false);
        }

        //Idle Parameter
        if (m_isIdle)
        {
            m_Animator.SetBool("isIdle", true);
        }
        else
        {
            m_Animator.SetBool("isIdle", false);
        }

        //Talking Parameter
        if (m_isTalking)
        {
            m_Animator.SetBool("isTalking", true);
        }
        else
        {
            m_Animator.SetBool("isTalking", false);
        }
    }
}

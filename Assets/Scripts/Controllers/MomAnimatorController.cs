using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomAnimatorController : MonoBehaviour
{
    public static MomAnimatorController sharedInstance;

    public bool m_isComplaining = false;
    public bool m_isDisapproving = false;
    public bool m_isIdle = false;
    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        sharedInstance = this;
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_isComplaining == true)
        {
            m_Animator.SetBool("IsComplaining", true);
            m_Animator.SetBool("IsDisapproving", false);
            m_Animator.SetBool("IsIdle", false);
        }
        else if(m_isDisapproving == true)
        {
            m_Animator.SetBool("IsComplaining", false);
            m_Animator.SetBool("IsDisapproving", true);
            m_Animator.SetBool("IsIdle", false);
        }
        else if(m_isIdle == true)
        {
            m_Animator.SetBool("IsComplaining", false);
            m_Animator.SetBool("IsDisapproving", false);
            m_Animator.SetBool("IsIdle", true);
        }
        else
        {
            m_Animator.SetBool("IsComplaining", false);
            m_Animator.SetBool("IsDisapproving", false);
            m_Animator.SetBool("IsIdle", false);
        }

    }

    

}

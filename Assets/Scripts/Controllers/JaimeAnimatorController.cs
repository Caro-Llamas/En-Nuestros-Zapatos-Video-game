using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaimeAnimatorController : MonoBehaviour
{
    [SerializeField] public bool m_isWalking = false;
    [SerializeField] public bool m_isArguint = false;
    [SerializeField] public bool m_isIdle = false;
    [SerializeField] public bool m_isSit = false;
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
            m_Animator.SetBool("isWalking", true);
        }
        else
        {
            m_Animator.SetBool("isWalking", false);
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

        //Arguing Animation states
        if (m_isArguint)
        {
            m_Animator.SetBool("isArguing", true);
        }
        else
        {
            m_Animator.SetBool("isArguing", false);
        }

        //Idle Animation states
        if (m_isIdle)
        {
            m_Animator.SetBool("isIdle", true);
        }
        else
        {
            m_Animator.SetBool("isIdle", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncleAnimatorController : MonoBehaviour
{
    [SerializeField] public bool m_IsWalking = false;
    [SerializeField] public bool m_IsIdle = true;
    [SerializeField] public bool m_IsHugging = false;

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
        if (m_IsWalking)
        {
            m_Animator.SetBool("IsWalking", true);
        }
        else
        {
            m_Animator.SetBool("IsWalking", false);
        }

        //Sitting Animation States
        if (m_IsHugging)
        {
            m_Animator.SetBool("IsHugging", true);
        }
        else
        {
            m_Animator.SetBool("IsHugging", false);
        }

        //Talking Animation states
        if (m_IsIdle)
        {
            m_Animator.SetBool("IsIdle", true);
        }
        else
        {
            m_Animator.SetBool("IsIdle", false);
        }
    }
}

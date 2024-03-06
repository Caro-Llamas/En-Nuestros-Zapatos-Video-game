using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public static PlayerAnimatorController sharedInstance;

    public bool m_isWalking = false;
    public bool m_isSit = false;
    public bool m_isIdle = false;
    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        sharedInstance = this;
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Keys down
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_Animator.SetBool("isWalk", true);
            m_Animator.SetBool("isIdle", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_Animator.SetBool("isWalk", true);
            m_Animator.SetBool("isIdle", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_Animator.SetBool("isWalk", true);
            m_Animator.SetBool("isIdle", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_Animator.SetBool("isWalk", true);
            m_Animator.SetBool("isIdle", false);
        }

        if (GameManager.sharedInstance.hasSituationEnded[10])
        {
            if (m_isWalking)
            {
                m_Animator.SetBool("isWalk", true);
            }
            else
            {
                m_Animator.SetBool("isWalk", false);
            }

            if (m_isIdle)
            {
                m_Animator.SetBool("isIdle", true);
            }
            else
            {
                m_Animator.SetBool("isIdle", false);
            }
        }



        //Keys up
        if (Input.GetKeyUp(KeyCode.W))
        {
            m_Animator.SetBool("isWalk", false);
            m_Animator.SetBool("isIdle", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            m_Animator.SetBool("isWalk", false);
            m_Animator.SetBool("isIdle", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            m_Animator.SetBool("isWalk", false);
            m_Animator.SetBool("isIdle", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            m_Animator.SetBool("isWalk", false);
            m_Animator.SetBool("isIdle", true);

        }

        //Sit animation
        if (m_isSit)
        {
            m_Animator.SetBool("isSit", true);
            m_Animator.SetBool("isIdle", false);
        }
        else
        {
            m_Animator.SetBool("isSit", false); 
            
        }

        
    }
}

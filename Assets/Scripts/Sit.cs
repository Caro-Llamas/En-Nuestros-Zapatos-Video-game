using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float playerWalkSpeed;
    private float playerRunSpeed;

    [SerializeField] private GameObject sitMark;
    [SerializeField] private GameObject standMark;
    private bool isPlayerInRange = false;
    public static bool hasSit = false;


    private void Start()
    {
        playerWalkSpeed = player.GetComponent<FirstPersonController>().m_WalkSpeed;
        playerRunSpeed = player.GetComponent<FirstPersonController>().m_RunSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            StartSitAnimation();
        }

        if(isPlayerInRange && Input.GetKeyDown(KeyCode.X))
        {
            StartStandUpAnimation();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            sitMark.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sitMark.SetActive(false);
            isPlayerInRange = false;
        }
    }

    private void StartStandUpAnimation()
    {
        standMark.SetActive(false);
        PlayerAnimatorController.sharedInstance.m_isSit = false;
        PlayerAnimatorController.sharedInstance.m_isIdle = true;

        player.GetComponent<FirstPersonController>().m_RunSpeed = playerRunSpeed;
        player.GetComponent<FirstPersonController>().m_WalkSpeed = playerWalkSpeed;
    }

    private void StartSitAnimation()
    {
        sitMark.SetActive(false);
        standMark.SetActive(true);
        player.GetComponent<FirstPersonController>().m_RunSpeed = 0;
        player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;

        PlayerAnimatorController.sharedInstance.m_isSit = true;
        PlayerAnimatorController.sharedInstance.m_isIdle = false;
    }
}

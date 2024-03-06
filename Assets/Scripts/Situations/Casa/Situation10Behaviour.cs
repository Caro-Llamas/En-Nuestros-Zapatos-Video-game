using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation10Behaviour : MonoBehaviour
{
    public static bool hasEnded;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject uncle;
    public GameObject exitTrigger;
    public GameObject actionMarkExit;
    private MoveToWaypoints uncleMotion;
    private UncleAnimatorController uncleAnimator;

    private bool uncleCanMove = true;
    private bool lastWp = false;
    public bool startDialogue = false;


    //private void Awake()
    //{
    //    hasEnded = GameManager.sharedInstance.hasSituationEnded[9];
    //}
    void Start()
    {
        uncleMotion = uncle.GetComponent<MoveToWaypoints>();
        uncleAnimator = uncle.GetComponent<UncleAnimatorController>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Dialogue.didDialogueStarted)
        {
            ChangeUncleAnimations();
            MoveUncle();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            exitTrigger.SetActive(false);
            actionMarkExit.SetActive(false);
            if (!startDialogue)
            {
                startDialogue = true;
                Dialogue.forceDialogue = true;
            }
            
        }
    }

    private void MoveUncle()
    {
        if (uncleCanMove)
        {
            uncleMotion.speed = 1.5f;
            uncleMotion.isStatic = false;

            uncleCanMove = false;
            lastWp = true;
        }
    }

    private void ChangeUncleAnimations()
    {
        if (Dialogue.didDialogueStarted)
        {
            if (uncleCanMove)
            {
                uncleAnimator.m_IsWalking = true;
                uncleAnimator.m_IsIdle = false;
            }
        }

        if (uncleMotion.isStatic && lastWp)
        {
            uncleAnimator.m_IsHugging = true;
            uncleAnimator.m_IsWalking = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uncleAnimator.m_IsHugging = false;
            uncleAnimator.m_IsIdle = true;

            uncle.transform.LookAt(new Vector3(player.transform.position.x,
                                            uncle.transform.position.y,
                                            player.transform.position.z));

            GameManager.sharedInstance.hasSituationEnded[9] = true;
        }
    }
}

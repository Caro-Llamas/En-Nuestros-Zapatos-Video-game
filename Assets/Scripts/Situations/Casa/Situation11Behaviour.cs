using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation11Behaviour : MonoBehaviour
{
    public static bool hasEnded;

    [SerializeField] private GameObject finalCameraPosition;

    [SerializeField] private GameObject jaime;
    private MoveToWaypoints jaimeMotion;
    private JaimeAnimatorController jaimeAnimator;
    [SerializeField] private GameObject character;

    [SerializeField] private GameObject player;
    private MovePlayerToWaypoints playerMotion;
    private PlayerAnimatorController playerAnimator;
    [SerializeField] private Transform SitTransform;

    //Cameras
    [SerializeField] private GameObject principalCamera;
    [SerializeField] private GameObject lastCamera;
    [SerializeField] private GameObject finalCamera;

    public bool finalSceneTrigger = false;
    public bool dialogueFinished = false;
    [SerializeField] private GameObject playerWp;
    public int thisDialogueLines = 20;

    //private void Awake()
    //{
    //    hasEnded = GameManager.sharedInstance.hasSituationEnded[10];
    //}

    // Start is called before the first frame update
    void Start()
    {
        lastCamera.SetActive(false);

        jaimeMotion = jaime.GetComponent<MoveToWaypoints>();
        jaimeAnimator = jaime.GetComponent<JaimeAnimatorController>();

        playerMotion = player.GetComponent<MovePlayerToWaypoints>();
        playerAnimator = player.GetComponentInChildren<PlayerAnimatorController>();
        //Debug.Log(playerAnimator);
        //Debug.Break();

    }

    // Update is called once per frame
    void Update()
    {

        if (Dialogue.didDialogueStarted || finalSceneTrigger)
        {
            if (!finalSceneTrigger)
            {
                ChangeActualCamera();
                finalSceneTrigger = true;
            }
            ChangeJaimeAnimations();

            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
        }

        if(Dialogue.lineIndex == thisDialogueLines)
        {
            if (!dialogueFinished)
            {
                dialogueFinished = true;
                MoveJaime();
                
                finalCameraPosition.SetActive(true);
                GameManager.sharedInstance.hasSituationEnded[10] = true;

                playerAnimator = player.GetComponentInChildren<PlayerAnimatorController>();
                GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayerToWaypoints>().enabled = true;
                MovePlayer();

                
            } 
            ChangeJaimeAnimations();
            ChangePlayerAnimations();
        }

        if (dialogueFinished)
        {
            playerWp.SetActive(true);

            StartJaimeSitAnimation();
            StartPlayerSitAnimation();
            //hasEnded = true;
        }
    }

    private void ChangeActualCamera()
    {
        principalCamera.GetComponent<Camera>().enabled = false;
        principalCamera.GetComponent<AudioListener>().enabled = false;
        lastCamera.SetActive(true);
    }

    private void MoveJaime()
    {
        jaimeMotion.speed = 2.0f;
        jaimeMotion.isStatic = false;
    }

    private void MovePlayer()
    {
        playerMotion.speed = 1.2f;
        playerMotion.isStatic = false;
    }

    private void ChangeJaimeAnimations()
    {
        if(Dialogue.lineIndex == 2 && jaimeMotion.isStatic)
        {
            jaimeAnimator.m_isArguint = true;
            jaimeAnimator.m_isIdle = false;
        }

        if (!jaimeMotion.isStatic)
        {
            jaimeAnimator.m_isWalking = true;
            jaimeAnimator.m_isArguint = false;
        }
    }

    private void StartJaimeSitAnimation()
    {
        if (jaimeMotion.isOnLastWaypoint)
        {
            jaimeMotion.targetToLook = character.transform;
            jaime.transform.LookAt(new Vector3(character.transform.position.x, jaime.transform.position.y, character.transform.position.z));
            
            jaimeAnimator.m_isWalking = false;
            jaimeAnimator.m_isSit = true;
        }
    }

    private void ChangePlayerAnimations()
    {
        if (!playerMotion.isStatic)
        {
            playerAnimator.m_isIdle = false;
            playerAnimator.m_isWalking = true;
        }
    }

    private void StartPlayerSitAnimation()
    {
        if (playerMotion.isOnLastWaypoint)
        {
            player.transform.LookAt(new Vector3(finalCamera.transform.position.x, player.transform.position.y, finalCamera.transform.position.z));
            playerAnimator.m_isWalking = false;
            playerAnimator.m_isSit = true;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        lastCamera.SetActive(false);
    //        finalCamera.SetActive(true);
    //    }
    //}
}

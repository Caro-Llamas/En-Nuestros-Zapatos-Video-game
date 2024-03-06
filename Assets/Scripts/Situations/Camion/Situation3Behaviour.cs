using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation3Behaviour : MonoBehaviour
{
    public static bool hasEnded;

    [SerializeField] private GameObject helper;
    private HelpersAnimatorController helpAnimator;
    private MoveToWaypoints helpMotion;
    private bool _isStandingHelp = true;
    private bool _isHelperSit = true;
    private bool _helpLeaving = true;

    [SerializeField] private GameObject acosador;
    private AcosadorAnimatorController acosAnimator;
    private MoveToWaypoints acosMotion;
    public float acosSpeed;

    public GameObject extraText;

    [SerializeField] private GameObject waypointToDeactivate;

    public GameObject dialogueMark;
    public bool activeMark = true;

    //private void Awake()
    //{
    //    hasEnded = GameManager.sharedInstance.hasSituationEnded[2];
    //}

    // Start is called before the first frame update
    void Start()
    {
        extraText.SetActive(true);
        helpAnimator = helper.GetComponent<HelpersAnimatorController>();
        helpMotion = helper.GetComponent<MoveToWaypoints>();

        acosAnimator = acosador.GetComponent<AcosadorAnimatorController>();
        acosMotion = acosador.GetComponent<MoveToWaypoints>();
        acosSpeed = acosMotion.speed;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAcosadorAnimations();
        ChangeHelperAnimations();

        if (GameManager.sharedInstance.hasSituationEnded[2])
        {
            extraText.SetActive(false);
            Waypoint.isAcosOnWaypoint = false;
        }

        if (PlayerAnimatorController.sharedInstance.m_isSit)
        {
            dialogueMark.SetActive(activeMark);
            if (Input.GetKeyDown(KeyCode.E))
            {
                activeMark = false;
                dialogueMark.SetActive(false);
            }

            MoveAcosador();

            if (Waypoint.isAcosOnWaypoint)
            {
                StopAcosador();    
            }

            if(Dialogue.didDialogueStarted && Dialogue.lineIndex == 0)
            {
                MoveHelper();
            }

            if(!Dialogue.didDialogueStarted && Dialogue.lineIndex == Dialogue.dialogueLinesLenght)
            {
                if (_helpLeaving)
                {
                    Waypoint.isHelpOnWaypoint = false;
                    helpMotion.targetToLook = GameObject.Find("HelWp2").transform;
                    helpMotion.transform.LookAt(new Vector3(helpMotion.targetToLook.position.x,
                                                                helpMotion.transform.position.y,
                                                                helpMotion.targetToLook.position.z));
                    _helpLeaving = false;
                }
                waypointToDeactivate.SetActive(false);
                MoveHelper();
            }

            if (Waypoint.isHelpOnWaypoint || Waypoint.isHelpOnLastWaypoint)
            {
                StopHelper();
            }
        }
    }

    private void MoveHelper()
    {
        helpMotion.isStatic = false;
        if (!_helpLeaving)
        {
            helpMotion.speed = acosSpeed;
        }
        StartCoroutine(WaitToMove());
    }

    private void StopHelper()
    {
        helpMotion.speed = 0;
        helpMotion.isStatic = true;
    }

    private void MoveAcosador()
    {
        acosMotion.speed = acosSpeed;
        acosMotion.isStatic = false;
    }

    private void StopAcosador()
    {
        acosMotion.speed = 0;
        acosMotion.isStatic = true;
    }

    private void ChangeHelperAnimations()
    {
        if (!helpMotion.isStatic)
        {
            if (_isStandingHelp)
            {
                helpAnimator.m_Type = 0;
                helpAnimator.m_IsSit = false;
                helpAnimator.m_IsStanding = true;
                _isHelperSit = false;
                StartCoroutine(WaitToStandUp());
            }

            if (!_isStandingHelp)
            {
                helpAnimator.m_IsStanding = false;
                helpAnimator.m_IsWalking = true;
            }
        }

        if (helpMotion.isStatic)
        {
            if (!_isHelperSit)
            {
                _isHelperSit = true;
                helpAnimator.m_IsWalking = false;
                helpAnimator.m_IsYelling = true;
            }
            
            if(Waypoint.isHelpOnLastWaypoint)
            {
                helpAnimator.m_IsWalking = false;
                helpAnimator.m_IsTalking = true;
            }
        }

        if (!Waypoint.isHelpOnWaypoint && !_helpLeaving && !Waypoint.isHelpOnLastWaypoint)
        {
            helpAnimator.m_IsWalking = true;
            helpAnimator.m_IsYelling = false;
        }
    }

    private void ChangeAcosadorAnimations()
    {
        if (!acosMotion.isStatic)
        {
            acosAnimator.m_isWalking = true;
            acosAnimator.m_isLean = false;
        }

        if (Waypoint.isAcosOnWaypoint)
        {
            acosAnimator.m_isWalking = false;
            acosAnimator.m_isHarassing = true;
        }
    }

    IEnumerator WaitToStandUp()
    {
        yield return new WaitForSeconds(0.5f);
        _isStandingHelp = false;
    }

    IEnumerator WaitToMove()
    {
        if (_helpLeaving)
        {
            yield return new WaitForSeconds(2.5f);
            helpMotion.speed = acosSpeed;
        }
        
    }
}

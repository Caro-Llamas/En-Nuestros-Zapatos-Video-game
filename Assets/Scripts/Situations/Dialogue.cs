using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float playerWalkSpeed;
    private float playerRunSpeed;

    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    
    private bool isPlayerInRange = false;
    public static bool didDialogueStarted = false;
    public static int lineIndex;
    public static int dialogueLinesLenght;
    private float typingTime = 0.05f;
    public static bool forceDialogue = false;

    private void Start()
    {
        playerWalkSpeed = player.GetComponent<FirstPersonController>().m_WalkSpeed;
        playerRunSpeed = player.GetComponent<FirstPersonController>().m_RunSpeed;

        dialogueLinesLenght = dialogueLines.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if((isPlayerInRange && Input.GetKeyDown(KeyCode.E)) || forceDialogue)
        {
            if (!didDialogueStarted)
            {
                StartDialogue();
                forceDialogue = false;
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            
        }

        //For testing
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.O))
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];
        }
    }

    private void StartDialogue()
    {
        didDialogueStarted = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;

        player.GetComponent<FirstPersonController>().m_RunSpeed = 0;
        player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;

        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStarted = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(false);
            //forceDialogue = false;

            if (!PlayerAnimatorController.sharedInstance.m_isSit)
            {
                player.GetComponent<FirstPersonController>().m_RunSpeed = playerRunSpeed;
                player.GetComponent<FirstPersonController>().m_WalkSpeed = playerWalkSpeed;
            }
            
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}

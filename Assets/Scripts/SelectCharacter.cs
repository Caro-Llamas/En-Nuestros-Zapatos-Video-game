using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private FirstPersonController playerMotion;

    [SerializeField] private GameObject principalCamera;
    [SerializeField] private GameObject charsCamera;
    [SerializeField] private GameObject characters;
    [SerializeField] private GameObject changeCharacterMark;
    [SerializeField] private GameObject selectCharsPanel;
    [SerializeField] private GameObject AcceptButton;
    
    public static bool isPlayerInRange = false;
    public static bool hasCharacterBeenSelected = false;
    private bool hideSelectMark = false;

    // Update is called once per frame
    void Update()
    {
        //Si no se tiene ningun texto en la cadena (no se ha seleccionado ningun personaje), el boton de aceptar no aparece
        if(GameManager.sharedInstance.characterSelected == "")
        {
            AcceptButton.SetActive(false);
        }
        else
        {
            AcceptButton.SetActive(true);
        }

        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !GameManager.sharedInstance.hasCharBeenSelected)
        {
            characters.SetActive(true);
            selectCharsPanel.SetActive(true);
            changeCharacterMark.SetActive(false);

            principalCamera.SetActive(false);
            charsCamera.SetActive(true);

            playerMotion.m_WalkSpeed = 0;
            playerMotion.m_RunSpeed = 0;
            playerMotion.m_MouseLook.SetCursorLock(false);

        }

        if (GameManager.sharedInstance.hasCharBeenSelected)
        {
            characters.SetActive(false);
            changeCharacterMark.SetActive(false);

            principalCamera.SetActive(true);
            charsCamera.SetActive(false);
            
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (!hideSelectMark)
            {
                hideSelectMark = true;
                changeCharacterMark.SetActive(true);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        switch (eventData.pointerPress.name)
        {
            case "SelectPF1":
                GameManager.sharedInstance.characterSelected = "playerF1";
                break;

            case "SelectPF2":
                GameManager.sharedInstance.characterSelected = "playerF2";
                break;

            case "SelectPF3":
                GameManager.sharedInstance.characterSelected = "playerF3";
                break;

            case "SelectPM1":
                GameManager.sharedInstance.characterSelected = "playerM1";
                break;

            case "SelectPM2":
                GameManager.sharedInstance.characterSelected = "playerM2";
                break;

            case "SelectPM3":
                GameManager.sharedInstance.characterSelected = "playerM3";
                break;
        }

        Debug.Log(GameManager.sharedInstance.characterSelected);
    }
}

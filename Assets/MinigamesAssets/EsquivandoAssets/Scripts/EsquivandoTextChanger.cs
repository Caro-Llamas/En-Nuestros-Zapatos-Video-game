using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EsquivandoTextChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text violentText;
    [SerializeField, TextArea(4, 6)] private string violentLines;

    void FixedUpdate()
    {
        ChangeTextRandomly();
    }

    private void ChangeTextRandomly()
    {
        if (EsquivandoManager.sharedInstance.gamePaused)
        {
            violentText.text = violentLines;
        }
    }
}

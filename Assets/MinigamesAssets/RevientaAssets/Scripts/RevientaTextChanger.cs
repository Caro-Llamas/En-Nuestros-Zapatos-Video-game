using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RevientaTextChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text violentText;
    [SerializeField, TextArea(4, 6)] private string[] violentLines;



    void FixedUpdate()
    {
        ChangeTextRandomly();
    }

    private void ChangeTextRandomly()
    {
        if (RevientaBall.canChangeText)
        {
            RevientaBall.canChangeText = false;
            violentText.text = violentLines[Random.Range(0, violentLines.Length)];
        }
    }
}

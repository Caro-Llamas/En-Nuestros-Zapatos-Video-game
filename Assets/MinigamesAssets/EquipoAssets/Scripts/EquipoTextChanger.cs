using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipoTextChanger : MonoBehaviour
{
    public float timeToWait = 10.0f;
    [SerializeField] private TMP_Text violentText;
    [SerializeField, TextArea(4, 6)] private string[] violentLines;

    private bool canChangeText = true;
    void FixedUpdate()
    {
        ChangeTextRandomly();
    }

    private void ChangeTextRandomly()
    {
        if (canChangeText)
        {
            violentText.text = violentLines[Random.Range(0, violentLines.Length)];
            canChangeText = false;
            StartCoroutine(WaitToChangeText());
        }
    }

    IEnumerator WaitToChangeText()
    {
        yield return new WaitForSeconds(timeToWait);
        canChangeText = true;
    }
}

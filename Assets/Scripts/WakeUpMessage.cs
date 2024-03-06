using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpMessage : MonoBehaviour
{
    public GameObject message;
    public GameObject firstThought;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.sharedInstance.hasGameBeenRestarted)
        {
            GameManager.sharedInstance.hasGameBeenRestarted = false;
            message.SetActive(true);
            firstThought.SetActive(true);

            StartCoroutine(HideMorningMessage(message));
        }
        else
        {
            message.SetActive(false);
        }
    }


    IEnumerator HideMorningMessage(GameObject message)
    {
        yield return new WaitForSeconds(7.0f);
        message.SetActive(false);
        firstThought.SetActive(false);
    }

}

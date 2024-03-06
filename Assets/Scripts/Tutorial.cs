using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject text;
    public GameObject movementSprites;
    public GameObject mouseLookSprites;

    public bool isPlayerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        HideTutorial(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            ShowTutorial();
        }
        else
        {
            HideTutorial();
            this.gameObject.SetActive(false);
        }
    }

    private void ShowTutorial()
    {
        text.SetActive(true);
        movementSprites.SetActive(true);
        mouseLookSprites.SetActive(true);
    }

    private void HideTutorial()
    {
        text.SetActive(false);
        movementSprites.SetActive(false);
        mouseLookSprites.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            
        }
    }
}

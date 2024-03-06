using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNextGuide : MonoBehaviour
{
    public GameObject nextGuide;

    void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Player"))
        {
            Show();
        }
    }


    void Show()
    {
        nextGuide.SetActive(true);
    }
}

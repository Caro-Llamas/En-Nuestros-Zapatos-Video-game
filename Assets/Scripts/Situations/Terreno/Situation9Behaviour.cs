using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation9Behaviour : MonoBehaviour
{
    public static bool hasEnded = false;
    public GameObject acosador;

    private void Start()
    {
        if (GameManager.sharedInstance.hasSituationEnded[1])
        {
            acosador.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FollowPlayer.startToFollow = true;
            GameManager.sharedInstance.hasSituationEnded[8] = true;
            
        }
    }
}

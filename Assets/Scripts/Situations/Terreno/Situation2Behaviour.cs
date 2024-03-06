using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation2Behaviour : MonoBehaviour
{
    public static bool hasEnded;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject acosador;
    private bool acosadorStartedLook = false;

    //private void Awake()
    //{
    //    hasEnded = GameManager.sharedInstance.hasSituationEnded[1];
    //}

    // Update is called once per frame
    void Update()
    {
        if (acosadorStartedLook)
        {
            AcosadorLookAtPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopPlayer();
            AcosadorLookAtPlayer();
            acosadorStartedLook = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.sharedInstance.hasSituationEnded[1] = true;
            
        }
    }

    private void AcosadorLookAtPlayer()
    {
        acosador.transform.LookAt(new Vector3(player.transform.position.x,
                                            acosador.transform.position.y,
                                            player.transform.position.z));
    }

    private void StopPlayer()
    {
        player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
        player.GetComponent<FirstPersonController>().m_RunSpeed = 0;
    }
}

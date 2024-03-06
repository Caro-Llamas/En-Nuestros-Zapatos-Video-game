using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource pianoAudio;
    public AudioClip pianoClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pianoAudio.clip = pianoClip;
            pianoAudio.PlayOneShot(pianoClip);
        }
        
    }
}

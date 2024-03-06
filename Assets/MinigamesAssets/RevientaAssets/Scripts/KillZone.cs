using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Pelota")
        {
            collision.GetComponent<RevientaBall>().ResetBall();
            RevientaBall.canChangeText = true;
        }
    }
}

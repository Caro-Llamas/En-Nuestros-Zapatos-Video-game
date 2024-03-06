using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Transform[] waypoints;
    int currentWaypoint = 0;

    public float speed = 0.3f;

    bool shouldWaitHome = false;
    

    private void Update()
    {
        if (EsquivandoManager.sharedInstance.invincibleTime > 0)
        {
            GetComponent<Animator>().SetBool("PacgirlInvincible", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("PacgirlInvincible", false);
        }
    }
    private void FixedUpdate()
    {
        if (EsquivandoManager.sharedInstance.gameStarted && !EsquivandoManager.sharedInstance.gamePaused)
        {
            if (!shouldWaitHome)
            {
                //Distancia entre el fantasma y el punto de destino
                float distanceToWaypoint = Vector2.Distance((Vector2)this.transform.position, (Vector2)waypoints[currentWaypoint].position);

                if (distanceToWaypoint < 0.1f)
                {
                    currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                    Vector2 newDirection = waypoints[currentWaypoint].position - this.transform.position;
                    GetComponent<Animator>().SetFloat("DirX", newDirection.x);
                    GetComponent<Animator>().SetFloat("DirY", newDirection.y);
                }
                else
                {
                    Vector2 newPos = Vector2.MoveTowards(this.transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
                    GetComponent<Rigidbody2D>().MovePosition(newPos);
                }
                GetComponent<AudioSource>().volume = 0.01f;
            }
        }
        else
        {
            GetComponent<AudioSource>().volume = 0.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Player")
        {
            if(EsquivandoManager.sharedInstance.invincibleTime <= 0)
            {
                StartCoroutine(RestartGame());
                EsquivandoManager.sharedInstance.RestartPosition();
                
            }
            else
            {
                UIManager_.sharedInstance.ScorePoints(1500);
                GameObject home = GameObject.Find("GhostHome");
                this.transform.position = home.transform.position;
                this.currentWaypoint = 0;
                this.shouldWaitHome = true;
                StartCoroutine("AwakeFromHome");
            }
        }   
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        //EsquivandoManager.sharedInstance.RestartGame();
    }

    IEnumerator AwakeFromHome()
    {
        yield return new WaitForSecondsRealtime(4.0f);
        this.shouldWaitHome = false;
        //Cada que el fantasma regresa a casa es 20% mas rápido
        this.speed *= 1.2f;
    }
}

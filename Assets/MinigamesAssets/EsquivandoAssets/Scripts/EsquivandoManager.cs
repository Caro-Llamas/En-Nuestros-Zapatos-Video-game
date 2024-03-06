using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EsquivandoManager : MonoBehaviour
{
    public static EsquivandoManager sharedInstance;

    public bool gameStarted = false;
    public bool gamePaused = true;

    public TMP_Text gameOverText;

    public GameObject startPacPoint;
    public GameObject pacgirl;
    public int pacLives = 1;

    public float invincibleTime = 0.0f;
    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }

        gameOverText.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(invincibleTime > 0)
        {
            invincibleTime -= Time.deltaTime;
        }
    }

    public void MakeInvincibleFor(float time)
    {
        this.invincibleTime += time;
    }

    public void RestartGame()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        gameStarted = true;
        gamePaused = false;
    }

    public void RestartPosition()
    {
        pacLives--;
        if (pacLives > 0)
        {
            pacgirl.transform.position = startPacPoint.transform.position;
            
        }

        if(pacLives == 0)
        {
            gameOverText.enabled = true;
            gamePaused = true;
            gameStarted = false;

        }
        
    }
}

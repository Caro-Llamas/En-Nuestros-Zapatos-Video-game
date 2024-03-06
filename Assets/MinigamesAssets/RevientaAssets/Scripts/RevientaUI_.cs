using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RevientaUI_ : MonoBehaviour
{
    public Image live1, live2, live3;
    public TMP_Text gameOverText;

    RevientaBall ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Pelota").GetComponent<RevientaBall>();
        gameOverText.enabled = false;
        live1.enabled = true;
        live2.enabled = true;
        live3.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.lives < 3)
        {
            live3.enabled = false;
        }

        if(ball.lives < 2)
        {
            live2.enabled = false;
        }

        if(ball.lives < 1)
        {
            live1.enabled = false;
            gameOverText.enabled = true;
        }
    }
}

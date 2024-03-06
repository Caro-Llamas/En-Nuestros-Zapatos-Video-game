using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_ : MonoBehaviour
{
    public static UIManager_ sharedInstance;

    public Text scoreLabel;

    private int totalScore;

    // Start is called before the first frame update
    void Awake()
    {
        totalScore = 0;
        if(sharedInstance == null)
        {
            sharedInstance = this;
        
        }
    }

    public void ScorePoints(int points)
    {
        totalScore += points;
        scoreLabel.text = "Score: "+totalScore;
    }
}

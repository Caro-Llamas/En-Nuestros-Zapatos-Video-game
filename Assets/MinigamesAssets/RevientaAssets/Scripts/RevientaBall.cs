using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevientaBall : MonoBehaviour
{
    public float speed = 10;
    public int lives = 3;

    public GameObject ballStartPos;

    public static bool canChangeText = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Pala")
        {
            float x = HitFactor(this.transform.position, collision.transform.position, collision.collider.bounds.size.x);

            Vector2 direction = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    float HitFactor(Vector2 ball, Vector2 paddle, float paddleWidth)
    {
        return ((ball.x - paddle.x) / paddleWidth);
    }

    public void ResetBall()
    {
        lives--;
        gameObject.transform.position = ballStartPos.transform.position;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if(lives > 0)
        {
            Invoke("RestartBallMovement", 2.0f);
        }
        
    }

    void RestartBallMovement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
}

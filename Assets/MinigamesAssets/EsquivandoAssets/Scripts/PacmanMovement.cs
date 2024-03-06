using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    public float speed = 0.4f;

    Vector2 destination = Vector2.zero;

    

    void Start()
    {
        destination = this.transform.position;
    }

    void FixedUpdate()
    {
        if (EsquivandoManager.sharedInstance.gameStarted && !EsquivandoManager.sharedInstance.gamePaused)
        {
            //MoveTowards hace un movimiento instantáneo
            Vector2 newPos = Vector2.MoveTowards(this.transform.position, destination, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(newPos);

            float distanceToDestination = Vector2.Distance((Vector2)this.transform.position, destination);

            if (distanceToDestination < 2)
            {
                if (Input.GetKey(KeyCode.UpArrow) && CanMoveTo(Vector2.up))
                    destination = (Vector2)this.transform.position + Vector2.up;

                if (Input.GetKey(KeyCode.DownArrow) && CanMoveTo(Vector2.down))
                    destination = (Vector2)this.transform.position + Vector2.down;

                if (Input.GetKey(KeyCode.RightArrow) && CanMoveTo(Vector2.right))
                    destination = (Vector2)this.transform.position + Vector2.right;

                if (Input.GetKey(KeyCode.LeftArrow) && CanMoveTo(Vector2.left))
                    destination = (Vector2)this.transform.position + Vector2.left;
            }

            Vector2 dir = destination - (Vector2)this.transform.position;
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);

            GetComponent<AudioSource>().volume = 0.01f;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0.0f;
            
        }
    }

    //|- Se dibuja una línea desde el punto a donde se quiere ir en direccion a pacman, para saber si puede moverse o no -|
    bool CanMoveTo(Vector2 dir)
    {
        Vector2 pacmanPos = this.transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pacmanPos + dir, pacmanPos);

        Collider2D pacmanCollider = GetComponent<Collider2D>();
        Collider2D hitCollider = hit.collider;

        return hitCollider == pacmanCollider; //si encuentra: collider de Pacman -> se puede mover, si no -> no movimiento
    }

    
}

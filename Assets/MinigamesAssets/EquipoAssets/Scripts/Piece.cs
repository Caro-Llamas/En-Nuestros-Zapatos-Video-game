using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    GameObject equipo;
    float lastFall = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        equipo = GameObject.Find("Equipo");
        StartCoroutine("CheckGameOver");
    }

    IEnumerator CheckGameOver()
    {
        yield return new WaitForSeconds(0.11f);
        if (!IsValidPiecePosition())
        {
            Debug.Log("GameOver");
            
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (equipo.activeSelf)
        {
            //Mover a la izquierda
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MovePieceHorizontally(-1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) //Mover a la derecha
            {
                MovePieceHorizontally(1);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow)) //Rotar la pieza
            {
                this.transform.Rotate(0, 0, -90);
                if (IsValidPiecePosition())
                {
                    UpdateGrid();
                }
                else
                {
                    this.transform.Rotate(0, 0, 90);
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || (Time.time - lastFall) > 1.0f)
            {
                this.transform.position += new Vector3(0, -1, 0);

                if (IsValidPiecePosition())
                {
                    UpdateGrid();
                }
                else
                {
                    this.transform.position += new Vector3(0, 1, 0);
                    //Como la pieza no puede bajar más, tal vez hay que borrar filas
                    GridHelper.DeleteAllFullRows();
                    //Hacemos que se spawnee una nueva ficha
                    FindObjectOfType<PieceSpawner>().SpawnNextPiece();
                    //Deshabilitamos el script para esta pieza
                    this.enabled = false;
                }

                lastFall = Time.time;
            }
        }
        
    }

    void MovePieceHorizontally(int direction)
    {
        this.transform.position += new Vector3(direction, 0, 0);

        //Comprobar si la nueva posicion es valida
        if (IsValidPiecePosition())
        {
            //Persisto la inforamción del movimiento en la parrilla del helper
            UpdateGrid();
        }
        else
        {
            //Si la posicon es invalida, se revierte el movimiento
            this.transform.position += new Vector3(-direction, 0, 0);
        }
    }

    bool IsValidPiecePosition()
    {
        foreach(Transform block in this.transform)
        {
            //posicion de cada hijo de la pieza
            Vector2 pos = GridHelper.RoundVector(block.position);

            //Si la posicion está fuera de los límites, no es una posición válida
            if (!GridHelper.IsInsideBorders(pos))
            {
                return false;
            }

            //Si ya hay otro bloque en la misma posición, no es válida la posicion
            Transform possibleObject = GridHelper.grid[(int)pos.x, (int)pos.y];

            //Para acceder a la propiedad de un objeto, ese objeto NUNCA debe ser nulo
            //Por eso, primero se verifica que exista el objeto
            if (possibleObject != null && possibleObject.parent != this.transform)
            {
                return false;
            }
        }

        return true;
    }

    void UpdateGrid()
    {
        //Borrar la vieja pieza
        for(int y = 0; y < GridHelper.height; y++)
        {
            for(int x = 0; x<GridHelper.width; x++)
            {
                if (GridHelper.grid[x, y] != null)
                {
                    if(GridHelper.grid[x,y].parent == this.transform)
                    {
                        GridHelper.grid[x, y] = null;
                    }
                }
            }
        }

        foreach(Transform block in this.transform)
        {
            Vector2 pos = GridHelper.RoundVector(block.position);
            GridHelper.grid[(int)pos.x, (int)pos.y] = block;
        }
    }
}

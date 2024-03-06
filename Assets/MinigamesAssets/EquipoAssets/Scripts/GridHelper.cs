using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHelper : MonoBehaviour
{
    public static int width = 10, height = 20+4; //20 de zona de juego + 4 de reserva al inicio para evitar erroes
    public static Transform[,] grid = new Transform[width, height];

   public static Vector2 RoundVector(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static bool IsInsideBorders(Vector2 pos)
    {
        if(pos.x >= 0 && pos.y >= 0 && pos.x < width)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void DeleteRow(int y)
    {
        for(int x = 0; x < width; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    //Baja una sola fila
    public static void DecreaseRow(int y)
    {
        for(int x= 0; x<width; x++)
        {
            if(grid[x,y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                //Repintamos el bloque, una posición más abajo en la pantalla
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    //Baja varias filas
    public static void DecreaseRowsAbove(int y)
    {
        for(int i=y; y< height; i++)
        {
            DecreaseRow(i);
        }
    }

    public static bool IsRowFull(int y)
    {
        for(int x=0; x < width; x++)
        {
            if(grid[x,y]== null)
            {
                return false;
            }
        }
        
        return true;
    }

    public static void DeleteAllFullRows()
    {
        for(int y= 0; y < height; y++)
        {
            if (IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                y--;
            }
        }
        CleanPieces();

    }

    public static void CleanPieces()
    {
        foreach (GameObject piece in GameObject.FindGameObjectsWithTag("Piece"))
        {
            //comprobando si la pieza tiene hijos, sino tiene a borrarla
            if (piece.transform.childCount == 0)
            {
                Destroy(piece);
            }
        }
    }
}

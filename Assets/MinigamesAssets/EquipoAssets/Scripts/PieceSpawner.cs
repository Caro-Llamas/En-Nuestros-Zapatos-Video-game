using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public GameObject[] levelPieces;

    public GameObject currentPiece, nextPiece;

    private void Start()
    {
        nextPiece = Instantiate(levelPieces[0], this.transform.position, Quaternion.identity);
        SpawnNextPiece();
    
    }

    public void SpawnNextPiece()
    {

        currentPiece = nextPiece;
        currentPiece.GetComponent<Piece>().enabled = true;
        
        StartCoroutine("PrepareNextPiece");
    }

    IEnumerator PrepareNextPiece()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        int i = Random.Range(0, levelPieces.Length);

        nextPiece = Instantiate(levelPieces[i], this.transform.position, Quaternion.identity);
        nextPiece.GetComponent<Piece>().enabled = false;
        
    }
}

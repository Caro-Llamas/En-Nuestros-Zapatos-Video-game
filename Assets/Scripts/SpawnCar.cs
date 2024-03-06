using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    [SerializeField] private GameObject[] cars = new GameObject[6];
    [SerializeField] private float timeToWait = 0f;
    public int rotationCar = 0;
    private Transform position;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform; //Obtaining the spawn position for the car
        position.Rotate(new Vector3(0, rotationCar, 0));
        position.localScale = new Vector3(2, 2, 2);
        StartCoroutine("WaitToSpawnCar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitToSpawnCar()
    {
        while (true)
        {
            SpawnRandomCar();
            yield return new WaitForSeconds(timeToWait);
        }
    }

    void SpawnRandomCar()
    {
        
        Instantiate(cars[Random.Range(0, 5)], position);
    }
}

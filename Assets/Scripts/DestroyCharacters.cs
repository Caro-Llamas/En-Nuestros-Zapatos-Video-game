using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCharacters : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Waypoint.isAcosOnLastWaypoint)
        {
            Destroy(GameObject.FindGameObjectWithTag("Acosador"));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}

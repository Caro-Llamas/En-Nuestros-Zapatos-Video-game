using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform nextWaypoint;
    public bool isLastWaypoint = false;
    public static bool isAcosOnWaypoint = false;
    public static bool isHelpOnWaypoint = false;

    public static bool isAcosOnLastWaypoint = false;
    public static bool isHelpOnLastWaypoint = false;

    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.CompareTag("Acosador") && this.name == "AcWp2") || (other.gameObject.name == "Acosador2" && this.name == "AcWp3"))
        {
            isAcosOnWaypoint = true;
        }

        if (other.gameObject.CompareTag("Acosador") && isLastWaypoint)
        {
            isAcosOnLastWaypoint = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Helper") && this.name == "HelWp1")
        {
            isHelpOnWaypoint = true;
        }

        if (other.gameObject.CompareTag("Helper") && isLastWaypoint)
        {
            isHelpOnLastWaypoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Acosador"))
        {
            isAcosOnWaypoint = false;
        }

        if(other.gameObject.name == "Camion2")
        {
            isHelpOnWaypoint = false;
        }
    }
}

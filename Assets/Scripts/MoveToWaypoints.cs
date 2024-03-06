using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoints : MonoBehaviour
{
    public static MoveToWaypoints sharedInstance;

    public float speed;
    public bool isStatic = false;
    public bool isOnLastWaypoint = false;
    public Transform targetToLook;
  
    // Start is called before the first frame update
    void Start()
    {
        sharedInstance = this;
        
        this.transform.LookAt(new Vector3(targetToLook.position.x, transform.position.y, targetToLook.position.z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStatic)
        {
            transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
            isStatic = false;
        }
        else
        {
            speed = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            Waypoint actualWp = other.gameObject.GetComponent<Waypoint>();
            
            if (!actualWp.isLastWaypoint)
            {
                targetToLook = actualWp.nextWaypoint;
                transform.LookAt(new Vector3(targetToLook.position.x, transform.position.y, targetToLook.position.z));
            }
            else
            {
                isOnLastWaypoint = true;
                speed = 0;
                isStatic = true;
            }
        }
    }
}
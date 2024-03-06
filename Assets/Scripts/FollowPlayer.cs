using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform directionToLook;
    [SerializeField] private AcosadorAnimatorController animator;

    public static bool startToFollow = false;
    public float speed = 3;

    // Update is called once per frame
    void Update()
    {
        if (startToFollow)
        {
            animator.m_isWalking = true;
            animator.m_isLean = false;

            transform.LookAt(new Vector3(player.transform.position.x,
                                            transform.position.y,
                                            player.transform.position.z));
            MoveForward();

        }
        else
        {
            transform.LookAt(directionToLook);
            MoveForward();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "TriggerFollower")
        {
            startToFollow = false;
        }
    }

    private void MoveForward()
    {
        transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardCar : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    CharacterController m_Controller;
    // Start is called before the first frame update
    void Start()
    {
        m_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        m_Controller.SimpleMove(forward * speed);
    }
}

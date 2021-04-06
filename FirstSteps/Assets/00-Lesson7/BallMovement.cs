using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float m_Speed = 8f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float factor = Time.deltaTime * m_Speed;
        rb.AddForce(new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"))*m_Speed*100*Time.deltaTime);
    }

}

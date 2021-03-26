using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    float timer;
    float m_Speed = 2f;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        timer = 0;
        print("enter");
    }

    void OnTriggerStay(Collider other)
    {
        other.transform.GetComponent<Animator>().SetFloat("Colour", Mathf.Clamp01(timer / 600f));
        print("stay");
    }
}

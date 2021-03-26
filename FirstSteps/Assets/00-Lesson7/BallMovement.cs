using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    float timer;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    float val = 0f;
    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
    timer = 0;
    }

    void OnTriggerStay(Collider other)
    {
        other.transform.GetComponent<Animator>().SetFloat("Colour", (timer / 600f));
    }
}

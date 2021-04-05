using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourController : MonoBehaviour
{
    float val = 0f;
    float colourSpeed = 0.8f;
    Animator animator;
    bool colliding;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (val > 0 && !colliding)
        {
            val -= Time.deltaTime * colourSpeed;
            animator.SetFloat("Colour", val);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (val < 1)
        {
            val += Time.deltaTime * colourSpeed;
            animator.SetFloat("Colour", val);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliding = true;
        animator.SetTrigger("GoDown");
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
        animator.SetTrigger("GoUp");
    }

}

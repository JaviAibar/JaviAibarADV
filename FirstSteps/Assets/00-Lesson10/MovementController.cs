using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float downaccel = 1;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       // characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(Vector3.down * downaccel * Time.deltaTime);
        float verticalValue = animator.GetFloat("Vertical");
        float horizontalValue = animator.GetFloat("Horizontal");
        float newVerticalValue;
        float newHorizontalValue;

        if (Input.GetKey(KeyCode.I)) // Go forward
        {
            newVerticalValue = Mathf.Min(1, verticalValue + speed);
        }
        else if (Input.GetKey(KeyCode.K)) // Go backwards
        {
            newVerticalValue = Mathf.Max(-1, verticalValue - speed);
        }
        else// Return to idle in vertical
        {
            newVerticalValue = Mathf.Lerp(verticalValue, 0, speed);
        }


        if (Input.GetKey(KeyCode.J)) // Turn left
        {
            newHorizontalValue = Mathf.Max(-1, horizontalValue - speed);
        }
        else if (Input.GetKey(KeyCode.L)) // Turn right
        {
            newHorizontalValue = Mathf.Min(1, horizontalValue + speed);
        }
        else // Return to idle in horizontal
        {
            newHorizontalValue = Mathf.Lerp(horizontalValue, 0, speed);

        }

        animator.SetFloat("Vertical", newVerticalValue);
        animator.SetFloat("Horizontal", newHorizontalValue);

       // GetComponent<NavMeshAgent>().destination = ;
    }
}

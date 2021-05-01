using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController_NavAgent : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform wine;
    [SerializeField] private GameObject wineInHand;
    private bool isJumping = false;
    //public Transform hand;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            wine.gameObject.SetActive(true);

            wine.GetComponent<Collider>().enabled = true;
           

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                wine.position = hit.point;
                agent.destination = wine.position;
                wine.GetComponent<AudioSource>().Play();
            }
        }
        if (agent.isOnOffMeshLink && !isJumping)
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
        } else if (!agent.isOnOffMeshLink && isJumping)
        {
            isJumping = false;
            
        } 

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Drinking"))
        {
            wineInHand.SetActive(true);
            agent.Stop();
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical",0);
        } else
        {
            agent.Resume();
            wineInHand.SetActive(false);
            Vector3 dir = transform.InverseTransformDirection(agent.velocity);
            print(agent.velocity);
            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wine"))
        {
            other.enabled = false;
           
            wine.gameObject.SetActive(false);
            animator.SetTrigger("Drink");
        }
    }
}

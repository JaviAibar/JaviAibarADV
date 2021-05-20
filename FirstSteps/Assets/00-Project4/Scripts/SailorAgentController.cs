using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SailorAgentController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    public bool isRunning;
    [SerializeField] private Animator _anim;
    public Transform destination;
    //public Transform hand;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        print(agent.isOnOffMeshLink);
        if (isRunning && agent.isOnOffMeshLink)
        {
            SetNewDestination();
        }
    }

    public void SetNewDestination()
    {
        agent.destination = new Vector3(Random.Range(-10, 10), transform.position.y, Random.Range(-10, 10));
        destination.position = agent.destination;
    }

    public void StartRunning()
    {
        isRunning = true;
        SetNewDestination();
        _anim.SetTrigger("Run");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destination"))
        {
            SetNewDestination();
        }
    }
}

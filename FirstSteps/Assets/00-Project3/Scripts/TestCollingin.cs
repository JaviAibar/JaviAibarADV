using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollingin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("TEST");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.name);
        
    }
}

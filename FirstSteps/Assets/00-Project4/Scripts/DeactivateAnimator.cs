using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAnimator : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        ActivateTheAnimator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeactivateTheAnimator()
    {
        animator.enabled = false;
    }

    void ActivateTheAnimator()
    {
        animator.enabled = true;
    }
}

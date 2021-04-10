using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourController : MonoBehaviour
{
    float val = 0f;
    float colourSpeed = 0.8f;
    Animator animator;
    ParticleSystem particleSys;
    bool colliding;
    private AudioSource _audio;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        particleSys = transform.parent.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        // When the ball steps off the button, the val decreases and the button return to the original state
        if (val > 0 && !colliding)
        {
            val -= Time.deltaTime * colourSpeed;
            animator.SetFloat("Colour", val);
        }
    }

    void OnCollisionStay(Collision other)
    {
        // As long as the ball collides the colliders of the buttons, the value increases
        // up to 1 and the animation starts to run along the value passed by argument
        if (val < 1)
        {
            val += Time.deltaTime * colourSpeed;
            animator.SetFloat("Colour", val);
        }
    }

    // The colliding flag in the following two methods is set because otherwise it'd be all the time
    // increasing and decreasing at the same time the variable val so the effect was like it was stopped
    private void OnCollisionEnter(Collision other)
    {
        colliding = true;
        animator.SetTrigger("GoDown");
        particleSys.Play();
        // When the ball starts colliding, the sound plays
        _audio.Play();
    }

    private void OnCollisionExit(Collision other)
    {
        colliding = false;
        animator.SetTrigger("GoUp");
        particleSys.Stop();
        // When the ball stops colliding, the sound stops as well
        _audio.Stop();
    }

}

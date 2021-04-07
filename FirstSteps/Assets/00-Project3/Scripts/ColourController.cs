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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        particleSys = transform.parent.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
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

    void OnCollisionStay(Collision other)
    {
        if (val < 1)
        {
            val += Time.deltaTime * colourSpeed;
            animator.SetFloat("Colour", val);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        colliding = true;
        animator.SetTrigger("GoDown");
        particleSys.Play();
        _audio.Play();
    }

    private void OnCollisionExit(Collision other)
    {
        colliding = false;
        animator.SetTrigger("GoUp");
        particleSys.Stop();
        _audio.Stop();
        // animator.StopPlayback("ParticleAnimationSystem");
    }

}

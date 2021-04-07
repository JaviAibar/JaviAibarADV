using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ButtonController : MonoBehaviour
{
    private Animator _animator;
    public Animator reactorFan;
    public Animator reactorFire;
    public GameObject particleSystems;
    public TMPro.TextMeshPro text;
    //private Animator textAnimator;
    public PlayableDirector timeline;
    private bool playMessage = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Collider")
        {
            text.text = "Click Space to activate engines!!";
            //  timeline.gameObject.SetActive(true);
            if (playMessage)
            {
                timeline.Play();
                playMessage = false;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwitchAllParticleSys();
                _animator.SetTrigger("SwitchEngine");
                reactorFan.SetTrigger("SwitchEngine");
                reactorFire.SetTrigger("SwitchEngine");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playMessage = true;
    }

    public void SwitchAllParticleSys()
    {
        foreach (ParticleSystem particleSys in particleSystems.GetComponentsInChildren<ParticleSystem>())
        {
            if (particleSys.isPlaying) particleSys.Stop(); else particleSys.Play();
        }
    }
}

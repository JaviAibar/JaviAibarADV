using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EngineController : MonoBehaviour
{
    private Animator _animator;
    public Animator reactorFan;
    public Animator reactorFire;
    public GameObject particleSystems;
    public TMPro.TextMeshPro text;
    //private Animator textAnimator;
    public PlayableDirector timeline;
    private bool playMessage = false;
    private AudioSource _audio;
    public AudioClip startEngineClip;
    public AudioClip loopEngineClip;
    public AudioClip stopEngineClip;
    public bool isPlaying = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        SwitchAllParticleSys();
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
                SwitchSounds();

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
            ParticleSystem.MainModule main = particleSys.main;
            main.startColor = Color.clear;
            particleSys.Play();
        }
    }

    public void SwitchSounds()
    {
        if (!isPlaying)
        {
            _audio.loop = true;
            isPlaying = true;
            _audio.loop = true;
            StartCoroutine(playEngineSound());
        }
        else
        {
            _audio.loop = false;
            _audio.clip = stopEngineClip;
            _audio.Play();
        }
        /*if (isPlaying)
        {

        } else
        {

        }*/
        // _audio.clip = audioClips[0];
        //_audio.Play();
    }



    IEnumerator playEngineSound()
    {
        _audio.clip = startEngineClip;
        _audio.Play();
        yield return new WaitForSeconds(_audio.clip.length);
        _audio.clip = loopEngineClip;
        _audio.Play();
    }
}

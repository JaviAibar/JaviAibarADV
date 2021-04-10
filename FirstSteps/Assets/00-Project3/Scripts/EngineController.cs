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
        // So it only activates with our interactable object in the camera
        if (other.name == "Collider")
        {
            text.text = "Click Space to switch the engines!!";
            if (playMessage)
            {
                timeline.Play();
                playMessage = false;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
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
        // This loop iterates over all the particle systems that the engine have and activates with black tint
        // The reason for this is that, we want it to be ready for colour fluctuation in the animations
        foreach (ParticleSystem particleSys in particleSystems.GetComponentsInChildren<ParticleSystem>())
        {
            ParticleSystem.MainModule main = particleSys.main;
            main.startColor = Color.clear;
            particleSys.Play();
        }
    }

    public void SwitchSounds()
    {
        // To start playing the sound of the engines
        if (!isPlaying)
        {
            _audio.loop = true;
            isPlaying = true;
            // we want 2 sounds play one after another
            // One of them (the ignition) will take a some time and then it will stop
            // and the second has to start in that moment, that's the reason of this Corouting (itemized down below)
            StartCoroutine(playEngineSound());
        }
        else
        {
            // This piece os code plays the switching off of the engines
            isPlaying = false;
            _audio.loop = false;
            _audio.clip = stopEngineClip;
            // The audio plays the stop of the engines
            _audio.Play();
        }
    }



    IEnumerator playEngineSound()
    {
        // We set start of engines sound
        _audio.clip = startEngineClip;
        _audio.Play();
        // We wait until it's over
        yield return new WaitForSeconds(_audio.clip.length);
        // then, we change the clip to the one that must be looped
        // it corresponds to the sound of the engines continously working
        _audio.clip = loopEngineClip;
        // The AudioSource plays in loop the sound of engines running
        _audio.Play();
    }
}

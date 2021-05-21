using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    private Animator _anim;
    private AudioSource _audio;
    private bool isHot = false;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space) && !_anim.GetCurrentAnimatorStateInfo(0).IsName("CannonGetsHot"))
        {
            //_anim.SetBool("isHot", isHot);
            _anim.SetTrigger("isHot");
            _audio.Play();
            print("SHOOOTING!!");
        }
    }
}

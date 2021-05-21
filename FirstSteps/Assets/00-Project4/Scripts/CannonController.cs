using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    private Animator _anim;
    private AudioSource _audio;
    private bool isHot = false;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject cannonBall;
    [SerializeField] private PirateController pirate;

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
            ThrowCannonBall(Vector3.right);
            _anim.SetTrigger("isHot");
            _audio.Play();
            pirate.Hit();
        }
    }

    public void ThrowCannonBall(Vector3 dir)
    {
        GameObject ball = Instantiate(cannonBall, transform);
        ball.transform.position += Vector3.up * 1.5f;
        Rigidbody ballRB = ball.GetComponent<Rigidbody>();
        ballRB.AddForce(dir * 30 * speed, ForceMode.Impulse);
        Destroy(ball, 12);
    }
}

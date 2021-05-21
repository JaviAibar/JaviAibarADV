using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateController : MonoBehaviour
{
    public float timer;
    public Animator cameraAnimator;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer % 5 < 0.01f)
        {
            print("HIT");
            cameraAnimator.SetTrigger("Hit");
        }
    }
}

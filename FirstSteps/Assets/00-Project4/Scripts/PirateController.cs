using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateController : MonoBehaviour
{
    public float timer;
    [SerializeField] private int lifes = 10;
    public Animator cameraAnimator;
    public ShipController ship;
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
            ship.Hit();
            cameraAnimator.SetTrigger("Hit");
        }
    }

    public void Hit()
    {
        if (lifes > 0)
        {
            lifes--;
        }
        else
        {
            print("You won!");
        }
    }
}

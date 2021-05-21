using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PirateController : MonoBehaviour
{
    public float timer;
    [SerializeField] private int lifes = 10;
    public Animator cameraAnimator;
    public ShipController ship;
    [SerializeField] private GameObject cannonBall;
    [SerializeField] private float speed = 2f;
    [SerializeField] private CannonController[] cannons;
    [SerializeField] private TextMeshProUGUI text;
    private bool shot = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer % 5 < 0.01f && !shot)
        {
            shot = true;
            ship.Hit();
            int rand = Random.Range(0, cannons.Length);
            cannons[rand].ThrowCannonBall(Vector3.left);

            StartCoroutine(ScreenShaking());

        } else 
        {
            shot = false;
        }
    }

    public void Hit()
    {
        if (lifes > 0)
        {
            lifes--;
            UpdateText();

        }
        else
        {
            print("You won!");
        }
    }
    public IEnumerator ScreenShaking()
    {
        yield return new WaitForSeconds(0.6f);

        cameraAnimator.SetTrigger("Hit");
    }

    public void UpdateText()
    {
        text.text = "" + lifes;

    }

}

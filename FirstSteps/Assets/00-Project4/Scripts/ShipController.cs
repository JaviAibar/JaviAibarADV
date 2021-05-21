using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipController : MonoBehaviour
{
    [SerializeField] private int lifes = 3;
    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

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
            print("You lost");
        }
    }

    public void UpdateText()
    {
        text.text = "" + lifes;
    }

  
}

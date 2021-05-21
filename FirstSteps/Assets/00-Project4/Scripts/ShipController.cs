using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipController : MonoBehaviour
{
    [SerializeField] private int lifes = 3;
    [SerializeField] private TextMeshProUGUI text;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        _anim = GetComponent<Animator>();
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
            _anim.SetTrigger("Sink");
        }
    }

    public void UpdateText()
    {
        text.text = "" + lifes;
    }

  
}

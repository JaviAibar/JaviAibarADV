using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestPadre : MonoBehaviour
{
    public float varibalePadre;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        print("NOOOOOO!!!");
    }

    public virtual void mensaje()
    {
        print("SÏ");
    }

    public abstract void Mensaje2();
}

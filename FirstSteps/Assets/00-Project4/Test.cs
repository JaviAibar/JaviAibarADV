using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : TestPadre
{
    public float varibaleHijo;
    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        //base.Update();
       // base.mensaje();
    }

    public virtual void mensajePadre()
    {
        base.mensaje();
    }

    public override void Mensaje2()
    {
        print("Mensaje pedoooorrooo");
    }
}

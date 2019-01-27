using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_StateIdle : Controller_StateBase
{

    public Controller_StateIdle(Controller Ctrl) : base(Ctrl)
    {
    }


    public override void Enter()
    {
        Exit();
        Ctrl.gameObject.AddComponent<Idle>();
    }

    public override void Excute()
    {
        
    }
    public override void Exit()
    {
        var obj = Ctrl.GetComponent<Idle>();
        if (obj != null)
            GameObject.Destroy(obj);
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_StateTracking : Controller_StateBase
{
    public Controller_StateTracking(Controller Ctrl) : base(Ctrl)
    {
    }


    public override void Enter()
    {
        Exit();
        Ctrl.gameObject.AddComponent<Tracking>();
    }

    public override void Excute()
    {

    }
    public override void Exit()
    {
        var obj = Ctrl.GetComponent<Tracking>();
        if (obj != null)
            GameObject.Destroy(obj);
    }

   


}

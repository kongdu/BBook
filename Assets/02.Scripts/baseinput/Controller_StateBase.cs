using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_StateBase
{

    protected Controller_StateMathine state;

    protected Base _base;

    protected Controller Ctrl;


    public Controller_StateBase(Controller Ctrl)
    {
        this.Ctrl = Ctrl;
    }

    /// <summary>
    /// 시작 로직
    /// </summary>
    public virtual void Enter()
    { }

    /// <summary>
    /// 실행 로직
    /// </summary>
    public virtual void Excute()
    { }

    /// <summary>
    /// 끝 로직
    /// </summary>
    public virtual void Exit()
    { }

   

}

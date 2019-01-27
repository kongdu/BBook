using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Controller_State {None ,Idle, Tracking }
public class Controller_StateMathine : MonoBehaviour
{

    public Controller_StateBase _base;

    Controller ctrl;
    // Start is called before the first frame update
    void Start()
    {
        ctrl = GetComponent<Controller>();
        ChangeState(Controller_State.None);
    }

    public void ChangeState(Controller_State nextState)
    {
        if (_base != null)
            _base.Exit();

        _base = Controller_ChangeState(nextState);

        _base.Enter();
    }



    public Controller_StateBase Controller_ChangeState(Controller_State _State)
    {
        switch (_State)
        {
            case Controller_State.None:
               return new Controller_StateNone(ctrl);
            case Controller_State.Idle:
                return new Controller_StateIdle(ctrl);
            case Controller_State.Tracking:
                return new Controller_StateTracking(ctrl);
        }

        return null;

    }
}

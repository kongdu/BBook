using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//3. 지진
namespace Yeon
{
    public class State_3Earthquake : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("3번");
            StateMachine.ChangeState(GetNextState());
        }

        public override void Execute()
        {
            base.Execute();
            var quaker = GameObject.Find("Quake").GetComponent<Quaker>();
            quaker.StartQuake(3,quaker.magnitude,quaker.duration);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override StateBase GetNextState()
        {
            return new State_4Playing();
        }
    }
}
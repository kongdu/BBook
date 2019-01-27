using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//4 플레이
namespace Yeon
{
    public class State_4Playing : StateBase
    {
        //테스트용 타임 수연이가 만든 타이머에서 가져와야함
    public float time = 20f;
        public override void Enter()
        {
            base.Enter();
            StateMachine.ChangeState(GetNextState());
        }

        public override void Execute()
        {
            base.Execute();
            var score = GameObject.Find("ScoreCheck").GetComponent<ScoreCheck>();
            if (score.CheckingNextState(time) == true)
            {
                GetNextState();
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override StateBase GetNextState()
        {
            return new State_5GameResult();
        }
    }
}
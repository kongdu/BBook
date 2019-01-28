using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2. 정답화면
namespace Yeon
{
    public class State_2AnswerScene : StateBase
    {
        private float runningTime = 5f;

        public override void Enter()
        {
            base.Enter();

            Debug.Log("2번 시작");
            StateMachine.ChangeState(GetNextState());
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("2번 실행중...");
            if (runningTime > 0)
            {
                runningTime -= Time.deltaTime;
                RefCtr.instance.showTime.text = "Time : " + Mathf.Round(runningTime);
            }
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("2번 끝");
        }

        public override StateBase GetNextState()
        {
            return new State_3Earthquake();
        }
    }
}
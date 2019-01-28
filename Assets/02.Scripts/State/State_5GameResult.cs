using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 5게임결과
namespace Yeon
{
    public class State_5GameResult : StateBase
    {
       

        

        public void ResultGame(bool Win)
        {
            if (Win) StateMachine.result = GameResult.WIN;
            else if (!Win) StateMachine.result = GameResult.LOSE;

            Debug.Log("WIn");
        }



        public override void Enter()
        {
            base.Enter();
            ResultGame(true);
            Debug.Log("5번");
          //  StateMachine.ChangeState(GetNextState());
        }

        public override void Execute()
        {
            base.Execute();
           
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override StateBase GetNextState()
        {
           return new State_6Ranking();
        }
    }
}
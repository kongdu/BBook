using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 5게임결과
namespace Yeon
{
    public class State_5GameResult : StateBase
    {
        public enum GameResult{ NONE , WIN , LOSE }
        public GameResult result = GameResult.NONE;

        

        public void ResultGame(bool Win)
        {
            if (Win) result = GameResult.WIN;
            else if (!Win) result = GameResult.LOSE;

            Debug.Log("WIn");
        }



        public override void Enter()
        {
            base.Enter();
            Debug.Log("5번");
          //  StateMachine.ChangeState(GetNextState());
        }

        public override void Execute()
        {
            base.Execute();
            ResultGame(true);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override StateBase GetNextState()
        {
            if (result == GameResult.WIN)
            {
                return new State_6Ranking();
            }
           

            return null;
        }
    }
}
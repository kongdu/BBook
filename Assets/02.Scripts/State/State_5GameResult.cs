using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 5게임결과
namespace Yeon
{
    public class State_5GameResult : StateBase
    {
        public void ResultGame(bool win)
        {
            if (win)
            {
                //StateMachine.result = GameResult.WIN;
                RefCtr.instance.winPanel.gameObject.SetActive(true);
            }
            else if (!win)
            {
                //StateMachine.result = GameResult.LOSE;
                RefCtr.instance.losePanel.gameObject.SetActive(true);
            }
            Debug.Log("WIn");
        }

        public override void Enter()
        {
            base.Enter();
            RefCtr.instance.playingPanel.gameObject.SetActive(false);

            ResultGame(State_4Playing.isGameOver);
            Debug.Log("5번");
            //StateMachine.ChangeState(GetNextState());
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
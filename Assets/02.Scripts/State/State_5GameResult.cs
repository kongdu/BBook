using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 5게임결과
namespace Yeon
{
    public class State_5GameResult : StateBase
    {

        public static float Result;

        public static void ResultScore(float Score)
        {
            Result = Score;
            //맞춘 정답 확률 계산

           float MaxResult = GameObject.Find("Quake").
                GetComponent<Quaker>().dropbooks;

            Result = (Result / MaxResult) * 100;
        }

        public static float Get_Score()
        {
            //게임매니져에 보낼 점수
            return Result;

        }



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
            RefCtr.instance.ResultText.text = State_5GameResult.Get_Score().ToString("") + "%";
            RefCtr.instance.playingPanel.gameObject.SetActive(false);

            //ResultGame(State_4Playing.isGameOver);
            ResultGame(false);
            Debug.Log("5번시작");
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
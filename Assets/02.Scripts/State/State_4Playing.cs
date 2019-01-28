using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//4 플레이
namespace Yeon
{
    public class State_4Playing : StateBase
    {
        private float totalTime = 20f;
        private bool isGameOver = false;

        public override void Enter()
        {
            base.Enter();
            Debug.Log("4번");
            RefCtr.instance.noticelPanel.gameObject.SetActive(false);
            RefCtr.instance.playingPanel.gameObject.SetActive(true);

            Controller1.TriggerControll = true;
            StateMachine.ChangeState(GetNextState());
            Debug.Log("4번 시작");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("4번 실행중...");
            var score = GameObject.Find("ScoreCheck").GetComponent<ScoreCheck>();

            if (!isGameOver && totalTime > 0)
            {
                totalTime -= Time.deltaTime;
                RefCtr.instance.showTime.text = Mathf.Round(totalTime) + "";
            }
            else
            {
                StateMachine.ChangeState(GetNextState());
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
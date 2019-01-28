using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//3. 지진
namespace Yeon
{
    public class State_3Earthquake : StateBase
    {
        private Quaker quaker = null;

        public override void Enter()
        {
            base.Enter();
            RefCtr.instance.showTime.gameObject.SetActive(false);
            RefCtr.instance.noticelPanel.gameObject.SetActive(true);

            Debug.Log("3번 시작");
            Debug.Log("3번");
            StateMachine.ChangeState(GetNextState());
        }

        public override void Execute()
        {
            base.Execute();

            Debug.Log("3번 실행중...");
            var quaker = GameObject.Find("Quake").GetComponent<Quaker>();
            var booksToDrop = (int)(StageManager.Instance.stageData[StageManager.Instance.stage]["DropBooks"]);
            quaker.StartQuake(booksToDrop, quaker.magnitude, quaker.duration);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override StateBase GetNextState()
        {
            return new State_4Playing();
        }

        private void OnCompleted()
        {
            Debug.Log("지진 끝!");

            quaker.OnCompleted -= OnCompleted;

            StateMachine.ChangeState(GetNextState());
        }
    }
}
﻿using System.Collections;
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

            quaker = GameObject.Find("Quake").GetComponent<Quaker>();
            quaker.OnCompleted += OnCompleted;
            quaker.StartQuake(3, quaker.magnitude, quaker.duration);

            Debug.Log("3번 시작");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("3번 실행중...");
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
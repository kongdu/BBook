using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yeon
{
    public enum GameState
    {
        WAITING_ROOM,  //1_대기실
        ANSWER_SCREEN, //2_정답화면 (몇초 보여줄까?)
        EARTHQUAKE,    //3_지진애니메이션+파티클 / (지진경보+게임방법)UI로 띄우기
        PLAYING,       //4_게임 중 (총 20초이지만 클리어조건 충족시 바로 게임 끝)
        GAME_RESULT,   //5_게임 결과 : 승패 보여주기
        RANKING        //6_랭킹  (우선순위 낮음)
    }

    public class GameManager : MonoBehaviour
    {
        //싱글턴을 위해 객체선언
        public static GameManager instance = null;

        //public static StateMachine stateMachine;
        //private Animator animator; //애니메이터로 상태머신 실습


        private StateBase stateBase = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(this.gameObject);
            }

            // animator = GetComponent<Animator>();
            StateMachine.ChangeState(new State_1WaitingRoom());
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2f);
        }

        private void Update()
        {
            StateMachine.Execute();
        }

        public void OnClick()
        {
            Debug.Log("OnClick (GameManager)");
            StateMachine.OnClick();
        }

        public void NEXT()
        {
           
            stateBase.GetNextState();


        }
        public void Quit()
        {
            //2번씬 이동 
            StateMachine.ChangeState(new State_2AnswerScene());
        }



    }
}
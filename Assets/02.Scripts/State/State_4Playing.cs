using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

//4 플레이
namespace Yeon
{
    public class State_4Playing : StateBase
    {
        private float totalTime = 20f;
        public static bool isGameOver = false;
        Quaker Quake = GameObject.Find("Quake").GetComponent<Quaker>();
        List<GameObject> book_list = GameObject.Find("Quake").GetComponent<Quaker>().Slotlist;
        public override void Enter()
        {
            base.Enter();
            Debug.Log("4번");
            RefCtr.instance.noticelPanel.gameObject.SetActive(false);
            RefCtr.instance.playingPanel.gameObject.SetActive(true);
            var Snapedlist = Quake.booknum;
            for (int i = 0; i < Quake.dropbooks; i++)
            {
                Snapedlist[i].Snaped = false;
            }
            Controller1.TriggerControll = true;
            //StateMachine.ChangeState(GetNextState());
            Debug.Log("4번 시작");
            Resultcounting();
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("4번 실행중...");
            var score = GameObject.Find("ScoreCheck").GetComponent<ScoreCheck>();

            if (StageManager.Instance.deadline > 0)
            {
                totalTime -= Time.deltaTime;
                RefCtr.instance.timer.text = Mathf.Round(totalTime) + "";
                //TO DO : 클리어조건 i) 빈공간 모두 채우면
            }
            else
            {
                // 책을 전부 꽃았을때의 조건도 추가해야할듯?
                isGameOver = !isGameOver;
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

        public void Resultcounting()
        {
            //var OBJS = GameObject.FindGameObjectsWithTag("bookshelf");
            
            //book_list.AddRange(OBJS);

            var ResultCnt = from slot in book_list
                            where slot.GetComponent<Book_Sh>().shelfNum == slot.GetComponent<Book_Sh>().Book_Check
                            select slot;

            int count = ResultCnt.Count();
            Debug.Log(count);
        }
    }
}
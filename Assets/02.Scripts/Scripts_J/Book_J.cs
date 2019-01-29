using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
책의 행동을 결정. StageManager로부터 '떨어져라'라는 신호를 받으면 지진 이펙트에서 흔드는 알고리즘에 따라 떨어지고,
기존 위치와 일정(BookManager가 갖는 거리) 이상 가까워지면 원 위치로 돌아가고 효과발생, BookManager에 정답갯수 올림.
*/

public class Book_J : MonoBehaviour
{
    //기존의 위치와 회전값를 가짐.
    private Vector3 initPos = Vector3.zero;

    //Vector3 initEulerRot = Quaternion.identity.eulerAngles;
    public Text title = null;

    public MeshRenderer _mesh;

    //이 책이 떨어져서 제자리를 찾아야 되는 책인지?
    public bool isQuestion = false;

    private void Awake()
    {
    }

    private void Update()
    {
        if (isQuestion)  //판정 조건을 컨트롤러에서 들어다 놓았을 때로 변경.
        {
            var posDif = (transform.position - initPos).magnitude;
            //var rotDif = Quaternion.sl
            if (posDif <= BookManager.Instance.correctDist)
            {
                RightAnswer();
            }
        }
    }

    public void SetText(string newTitle)
    {
        title.text = newTitle;
    }

    public void SetColor(Color color)
    {
        _mesh.material.color = color;
    }

    /// <summary>
    /// 정답일 때 작동. 위치와 회전을 원위치 시키고, 상호작용을 못하도록 함.
    /// </summary>
    private void RightAnswer()
    {
        if (isQuestion)
        {
            isQuestion = false;
            transform.position = initPos;

            //TODO: 상호작용 불가능하도록 하는 작업. 레이어.
            gameObject.layer = 0;
            //StageManager.Instance.ClearBook();
            CorrectEffect();
        }
    }

    private void CorrectEffect()
    {
    }

    public void MemorizePos()
    {
        initPos = transform.position;
    }

    public void MakeQuestion()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * -100f);
        isQuestion = true;
        gameObject.layer = 9;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base :MonoBehaviour
{

    

    //저장용 책 게임오브젝트
    //[HideInInspector]
    public GameObject HitGO;

    public Controller_StateBase _statebase;

    public Controller dir_Ctrl;
    private void Awake()
    {
        reset();
    }

    protected virtual void reset()
    {
        dir_Ctrl = this.gameObject.GetComponent<Controller>();
    }



    public IEnumerator Tracking_Move(Move_pos pos)
    {
        //책을 계속 가지고 있을경우에만 책을 끌어당긴다.
        while (dir_Ctrl.dir_Poser.hitDistance >= 0.1f && (HitGO))
        {
            HitGO.transform.position =
                Vector3.Lerp(
                    pos.first.transform.position,
                    pos.last.position, Time.deltaTime * 5.0f
                    );

            yield return null;
        }
    }

    public void Mv(Move_pos pos)
    {
        StartCoroutine(Tracking_Move(pos));
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Utility;
using HTC.UnityPlugin.Vive;





public class Controller1 : MonoBehaviour {

    public HandRole handRole;

    public ControllerButton controllerButton;
    
    public Transform HandTransform;
    
    public Transform OriginParent;

    public GameObject HitBook;

    public ReticlePoser reticlePoser;

    public bool Tracking = false;

    public float distance;

    public Transform Stack_Direction_book;

    public GameObject dirRaycast;

    private void Update()
    {
        //트리거 다운 할때
        if (ViveInput.GetPressDownEx(handRole, controllerButton))
        {
            if (StackManager.stack_list.Count == 0 && 
                reticlePoser.hitTarget == null ) return;

            //스택에서 꺼내기 
            if (reticlePoser.hitTarget == null ||
                StackManager.stack_list.Count > 0  &&
                reticlePoser.hitTarget.GetComponent<Book>().Stack_on)
            {
                Tracking = true;

                //(처리)
               // HitBook = InputManager.book_stack_Transforms
               //             [InputManager.book_stack_Transforms.Count - 1].gameObject;

                HitBook = StackManager.Stack_PoP(HitBook);

                HitBook.transform.SetParent(HandTransform);

                HitBook.transform.position =
                            HandTransform.position + HandTransform.transform.forward * 0.2f;

                HitBook.transform.localRotation = Quaternion.Euler(0, 0, 0);

                HitBook.GetComponent<Book>().Stack_on = false;

                StackManager.stack_list.Remove(HitBook.transform);
                //Tracking_move();
            }

            else
            {
                //집은 책이 스택에 들어가있지 않다면 
                if (!reticlePoser.hitTarget.GetComponent<Book>().Stack_on &&
                    !reticlePoser.hitTarget.GetComponent<Book>().Snaped)
                {
                    //(처리)
                    HitBook = reticlePoser.hitTarget;
                    Tracking = true;
                    Tracking_move();
                }
                else //집은 녀석이 스택에 들어가있다면 
                {
                    StackManager.stack_list.Remove(reticlePoser.hitTarget.transform);
                }
                
            }
        }
        //트리거 업
        if (ViveInput.GetPressUpEx(handRole, controllerButton))
        {
            // if (HitBook == null || reticlePoser.hitTarget == null) return;

            //1. 다시 스택에 집어넣기 

            //2. 책장에 집어넣기

            //3. 스택이 5개 일떄 스택에 집어넣지않고 떨구기.

            //4. 책장에 들어가있지 않다면 스택에 다시 넣기.

            //5. 스냅중이 라면 위치 각도 고정


            if (!HitBook.GetComponent<Book>().Snaped &&
                StackManager.stack_list.Count < 5)
            {
                if (StackManager.stack_list.Count <= 0)
                {
                    HitBook.transform.position =
                        Stack_Direction_book.position + (Vector3.up * (0.11f));
                }
                else
                {
                    HitBook.transform.position =
                            StackManager.stack_list
                            [StackManager.stack_list.Count - 1].transform.position +
                            (Vector3.up * (0.11f));
                }

                StackManager.Stack_Push(HitBook);

                HitBook = StackManager.stack_list
                    [StackManager.stack_list.Count - 1].gameObject;

                HitBook.GetComponent<Book>().Stack_on = true;

                HitBook.transform.SetParent(Stack_Direction_book);

                HitBook.transform.rotation = Quaternion.Euler(0, 0, 90.0f);

            }
            // 책장에 들어가있다면 
            else if (HitBook.GetComponent<Book>().Snaped)
            {
                HitBook.GetComponent<Book>().Stack_on = false;
                HitBook.GetComponent<Book>().Snaped = true;

                //책의 원래 위치 각도
                HitBook.GetComponent<Book>().SnapBook();
                //책의 원래 위치 오브젝트
                HitBook.GetComponent<Book>().other.SetActive(false);
                HitBook.transform.SetParent(OriginParent);

            }
            else
            {
                HitBook.transform.SetParent(OriginParent);
            }

            HitBook = null;
            Tracking = false;
        }
        
        Distance();
    }

    public void Distance()
    {
        if (HitBook && reticlePoser.hitTarget)
        {
            distance = Vector3.Distance(HandTransform.position, HitBook.transform.position);
        }

    }

    public void Tracking_move()
    {
        //책이 선택됫다. 
        if (HitBook)
        {
            //책의 부모를 반대쪽 손으로 변경
            HitBook.transform.SetParent(HandTransform);
            //책의 각도를 변경
            HitBook.transform.localRotation = Quaternion.Euler(Vector3.zero);
            //책을 이동 시킴.
            StartCoroutine(Tracking_OBJ());
        }

    }

    IEnumerator Tracking_OBJ()
    {
        //책을 계속 가지고 있을경우에만 책을 끌어당긴다.
        while (reticlePoser.hitDistance >= 0.1f  && (HitBook))
        {
            HitBook.transform.position =
                Vector3.Lerp(
                    HitBook.transform.position,
                    HandTransform.position , Time.deltaTime*5.0f
                    );

            yield return null;
        }

      
    }
   

}

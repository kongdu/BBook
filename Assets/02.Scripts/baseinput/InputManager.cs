using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Move_pos
{
    public Transform first;
    public Transform last;
}

public class InputManager : MonoBehaviour
{
    private static InputManager _instance = null;
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(InputManager)) as InputManager;
                if (_instance == null)
                {
                    Debug.LogError("Error");
                }
            }

            return _instance;
        }
    }




   
    public Move_pos pos;

    public InputManager()
    {
        pos = new Move_pos();
    }
}



//Idle_state 일떄  Idle 를 Addconponent<Idle>
//1. 아무것도 안하거나 정답칸에 넣던가(이것도 그냥 놔 버리는것.)
//2. 스택에 넣거나

//Tracking_state 일때  Tracking 를 Addconponent<Tracking>
//1. 집은 책을 끌어오거나
//2. 스텍에서 빼오거나(스텍에 책이 들어있으면)
//2-1. 스텍에 책이 없다면 아무짓도 안함.
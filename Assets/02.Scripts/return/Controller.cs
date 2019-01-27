using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Utility;
using HTC.UnityPlugin.Vive;


public class Controller : MonoBehaviour
{
    public enum Direction {NONE,RIGHT,LEFT}
    public Direction dir = Direction.NONE;

    public ReticlePoser dir_Poser;

    public Controller_StateMathine _StateMathine;

    public Transform    dir_Hand;

    public HandRole handRole;

    public void Awake()
    {
        dir_Hand = GetComponentInChildren<Transform>();
        _StateMathine = GetComponent<Controller_StateMathine>();
    }


    void Startbutton()
    {
        if (dir_Poser.hitTarget.tag == "startbutton")
            dir_Poser.hitTarget.SetActive(false);
    }
    private void Update()
    {
        if (ViveInput.GetPressDown(handRole, ControllerButton.Axis1))
        {
            Startbutton();


            if (handRole == HandRole.RightHand)
                dir = Direction.RIGHT;
            if (handRole == HandRole.LeftHand)
                dir = Direction.LEFT;

            if (dir != Direction.NONE)
                _StateMathine.ChangeState(Controller_State.Tracking);


        }
        if (ViveInput.GetPressUp(handRole, ControllerButton.Axis1))
        {
            dir = Direction.NONE;
            _StateMathine.ChangeState(Controller_State.Idle);
        }


    }
        



}

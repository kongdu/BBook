using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Utility;
using HTC.UnityPlugin.Vive;

public enum Direction {NONE,RIGHT,LEFT}

public class Controller : MonoBehaviour
{
    public Direction dir = Direction.NONE;

    public ReticlePoser dir_Poser;
    public Transform    dir_Hand;

    public HandRole handRole;

    public ControllerButton controllerButton;

    private void Update()
    {
        if (ViveInput.GetPressDownEx(handRole, controllerButton))
        {
            if (handRole == HandRole.RightHand)
                dir = Direction.RIGHT;
            if (handRole == HandRole.LeftHand)
                dir = Direction.LEFT;

        }
        if (ViveInput.GetPressUpEx(handRole, controllerButton))
        {
            dir = Direction.NONE;
        }


    }
        



}

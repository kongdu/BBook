using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DefaultExecutionOrder(-20000)]
public class DebuggerEnable : MonoBehaviour
{
    private void Start()
    {
#if !UNITY_EDITOR
        Debug.unityLogger.logEnabled = false;
#endif
        Log("Hi");
    }

#if UNITY_EDITOR

    private void Log(string msg)
    {
    }

#else
    private void Log(string msg)
    {
    }
#endif
}
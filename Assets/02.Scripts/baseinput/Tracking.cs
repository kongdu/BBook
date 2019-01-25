using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : Base
{

    
    public Tracking()
    {
        if(pos.first != null && pos.last != null)
        Mv(pos);
    }


    public void Push(GameObject obj,Transform dir)
    {
        StackManager.Stack_Push(obj);

        obj = StackManager.stack_list
            [StackManager.stack_list.Count - 1].gameObject;

        obj.GetComponent<Book>().Stack_on = true;

        obj.transform.SetParent(dir);

        obj.transform.rotation = Quaternion.Euler(0, 0, 90.0f);
    }









}

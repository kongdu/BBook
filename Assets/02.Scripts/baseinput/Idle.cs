using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Base
{


    public Idle()
    {
        if (pos.first != null && pos.last != null)
            Mv(pos);
    }


    public GameObject PoP(GameObject obj , Transform dir)
    {
        obj = StackManager.Stack_PoP(obj);

        obj.transform.SetParent(dir);

        
        pos.last.position = obj.transform.position =
                    dir.position + dir.transform.forward * 0.2f;

        pos.first.position = StackManager.stack_list
            [StackManager.stack_list.Count - 1].position;

        obj.transform.localRotation = Quaternion.Euler(0, 0, 0);

        obj.GetComponent<Book>().Stack_on = false;

        StackManager.stack_list.Remove(obj.transform);

        return obj;
    }

    public void Mover(GameObject obj, Transform dir)
    {
        pos.first.position = dir_Ctrl.dir_Poser.hitTarget.transform.position;
        pos.last.position = obj.transform.position =
                    dir.position + dir.transform.forward * 0.2f;
    }






}

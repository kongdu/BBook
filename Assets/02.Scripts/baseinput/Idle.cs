using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Base
{
    //타겟으로 집고 있는것이 책이라면 
    //타겟을 저장하고 
    protected override void reset()
    {
        base.reset();
    }

    private IEnumerator Corutine_Mv()
    {
        yield return new WaitForSeconds(0.1f);
        IdleMv();
    }


    public void IdleMv()
    {
        if (InputManager.Instance.pos.first != null 
            && InputManager.Instance.pos.last != null)
            Mv(InputManager.Instance.pos);
    }
    private IEnumerator Corutine_Save()
    {
        yield return new WaitForSeconds(0.1f);
        Target_Save(dir_Ctrl.dir_Poser.hitTarget);

    }

    public void Target_Save(GameObject target)
    {
        if (target != null)
            HitGO = target;
        else
            HitGO = null;
    }
    private IEnumerator Corutine_Push()
    {
        yield return new WaitForSeconds(0.1f);
        Push(HitGO, dir_Ctrl.transform);

    }



    public void Push(GameObject obj, Transform dir)
    {
        StackManager.Stack_Push(obj);

        obj = StackManager.stack_list
            [StackManager.stack_list.Count - 1].gameObject;

        obj.GetComponent<Book>().Stack_on = true;

        obj.transform.SetParent(dir);

        obj.transform.rotation = Quaternion.Euler(0, 0, 90.0f);
    }


    //이동할 위치저장 
    public void Mover_Save(GameObject obj, Transform dir)
    {
        InputManager.Instance.pos.first.position = dir_Ctrl.dir_Poser.hitTarget.transform.position;
        InputManager.Instance.pos.last.position = obj.transform.position =
                    dir.position + dir.transform.forward * 0.2f;
    }






}

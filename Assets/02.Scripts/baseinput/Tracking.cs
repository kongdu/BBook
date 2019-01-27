using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : Base
{
    protected override void reset()
    {
        base.reset();
    }

    //스테이트가 변하면 
    //트래킹 상태일때 hitgo가 널이 아니라면 
    private void OnEnable()
    {
        //조건으로 호출시킴
    }

    private IEnumerator Corutine_Mv()
    {
        yield return new WaitForSeconds(0.1f);
        TrackingMv();
    }

    private IEnumerator Corutine_PoP()
    {
        yield return new WaitForSeconds(0.1f);
        PoP(HitGO, dir_Ctrl.transform);
    }





    public void TrackingMv()
    {
        if(InputManager.Instance.pos.first != null &&
            InputManager.Instance.pos.last != null)
        Mv(InputManager.Instance.pos);
    }

    //스텍에 있는걸 뺀다. 
    public GameObject PoP(GameObject obj, Transform dir)
    {
        obj = StackManager.Stack_PoP(obj);

        obj.transform.SetParent(dir);


        InputManager.Instance.pos.last.position = obj.transform.position =
                    dir.position + dir.transform.forward * 0.2f;

        InputManager.Instance.pos.first.position = StackManager.stack_list
            [StackManager.stack_list.Count - 1].position;

        obj.transform.localRotation = Quaternion.Euler(0, 0, 0);

        obj.GetComponent<Book>().Stack_on = false;

        StackManager.stack_list.Remove(obj.transform);

        return obj;
    }







}

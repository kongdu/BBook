using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static List<Transform> stack_list = new List<Transform>();

    /// <summary>
    /// 스텍 마지막 마지막부분의 오브젝트
    /// </summary>
    public static GameObject Stack_PoP(GameObject book)
    {
        book = stack_list[stack_list.Count - 1].gameObject;
        return book;
    }

    /// <summary>
    /// 스텍에 Push
    /// </summary>
    /// <param name="book"></param>
    public static void Stack_Push(GameObject book)
    {
        stack_list.Add(book.transform);
    }


  



}
